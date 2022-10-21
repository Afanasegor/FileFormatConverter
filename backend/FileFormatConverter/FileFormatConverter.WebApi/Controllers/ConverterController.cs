using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileFormatConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IFileConverterFactory _fileConverterFactory;
        private readonly IBatchService _batchService;
        private readonly IMainService _mainService;
        private readonly IFileService _fileService;
        private readonly ILogger<ConverterController> _logger;

        public ConverterController(IFileConverterFactory fileConverterFactory, IBatchService batchService, IMainService mainService, IFileService fileService, 
            ILogger<ConverterController> logger)
        {
            _fileConverterFactory = fileConverterFactory;
            _batchService = batchService;
            _mainService = mainService;
            _fileService = fileService;
            _logger = logger;
        }

        [HttpGet("check-status")]
        public async Task<IActionResult> GetStatus(Guid id)
        {
            var result = await _batchService.GetBatchById(id);

            if (result == null) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result.ProcessStatus.ToString());
        }

        [HttpGet("download-converted-file")]
        public async Task<IActionResult> DownloadConvertedFile(Guid id)
        {
            var batch = await _batchService.GetBatchById(id);

            if (batch.ProcessStatus != ProcessStatus.Completed)
                return StatusCode(StatusCodes.Status400BadRequest);

            var file = await _fileService.GetById(batch.TargetFileId);

            if (file == null || string.IsNullOrWhiteSpace(file.FilePath))
            {
                _logger.LogWarning("File doesn't exist yet, bathc id: {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var fileName = file.FilePath.Split(@"\").LastOrDefault();
            var fileBytes = System.IO.File.ReadAllBytes(file.FilePath);

            return File(fileBytes, "application/force-download", fileName);
        }

        /// <returns>Batch id</returns>
        [HttpPost("convert")]
        public async Task<IActionResult> Convert(IFormFile file, ConverterType converterType)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("Bad request, because file is empty");
                return BadRequest("There is no file added");
            }

            byte[] fileInByteArray;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileInByteArray = ms.ToArray();
            }

            var fileName = file.FileName;

            var batchId = await _mainService.StartConverting(fileInByteArray, converterType, fileName);
            return Ok(batchId);
        }
    }
}
