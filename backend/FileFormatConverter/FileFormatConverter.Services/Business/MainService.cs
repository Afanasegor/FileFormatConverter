using FileFormatConverter.Core.Utils;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Utils.Converters;
using Hangfire;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Business
{
    public class MainService : IMainService
    {
        // TODO: move to config
        private const string ORIGIN_FILE_NAME = "created";
        private const string ORIGIN_PATH = "origin-files";

        private readonly IFileService _fileService;
        private readonly IBatchService _batchService;

        public MainService(IFileService fileService, IBatchService batchService)
        {
            _fileService = fileService;
            _batchService = batchService;
        }

        public async Task<Guid> StartConverting(byte[] file, ConverterType converterType, string fileName)
        {
            if (!ConverterTypeValidator.IsFileValid(fileName, converterType))
            {
                throw new ArgumentException("File format isn't considering converter type", "fileName");
            }

            var originFileName = GenerateUniqueName(ORIGIN_FILE_NAME);
            var originPath = Path.Combine(Directory.GetCurrentDirectory(), ORIGIN_PATH);
            var originFileFormat = converterType.ConvertToOriginalFileFormat();

            var fileInfo = await _fileService.CreateFile(file, originPath, originFileName, originFileFormat);

            var fileInput = fileInfo.ConvertToInputFileInfo(originFileFormat, converterType, fileName);

            var batchModel = await _batchService.CreateBatch(fileInput);

            BackgroundJob.Enqueue<IConverterJob>(job => job.ConvertByBatchIdAsync(batchModel.Id));

            return batchModel.Id;
        }

        private string GenerateUniqueName(string name)
        {
            var result = name + DateTime.Now.ToFullString();
            return result;
        }
    }
}
