using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Utils.Converters;
using System;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Business
{
    public class ConverterJob : IConverterJob
    {
        private readonly IFileService _fileService;
        private readonly IBatchService _batchService;
        private readonly IFileConverterFactory _fileConverterFactory;

        public ConverterJob(IFileService fileService, IBatchService batchService, IFileConverterFactory fileConverterFactory)
        {
            _fileService = fileService;
            _batchService = batchService;
            _fileConverterFactory = fileConverterFactory;
        }
        public async Task ConvertByBatchIdAsync(Guid batchId)
        {
            var batchToProcess = await _batchService.GetBatchById(batchId);

            try
            {
                if (batchToProcess == null)
                {
                    throw new ArgumentException($"No batch with id {batchId} in database");
                }

                await _batchService.ChangeStatus(batchId, ProcessStatus.InProgress);

                var originFileInfo = await _fileService.GetById(batchToProcess.OriginFileId);

                var converter = _fileConverterFactory.GetFileConverter(batchToProcess.ConverterType);
                var targetFullPath = await converter.Convert(originFileInfo.FilePath);

                var targetFileFormat = batchToProcess.ConverterType.ConvertToTargetFileFormat();
                var createdResult = await _fileService.CreateRecordOfFile(targetFullPath.FilePath, targetFileFormat);

                var inputTargetFileInfo = createdResult.ConvertToInputFileInfo(targetFileFormat, batchToProcess.ConverterType);

                await _batchService.AddTargetFileInfoToBatch(batchToProcess.Id, inputTargetFileInfo);
                await _batchService.ChangeStatus(batchToProcess.Id, ProcessStatus.Completed);
            }
            catch (Exception)
            {
                await _batchService.ChangeStatus(batchToProcess.Id, ProcessStatus.Error);
            }
        }
    }
}
