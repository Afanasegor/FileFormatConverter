using FileFormatConverter.Core.Utils;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileFormatConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetFileById(Guid id)
        {
            var result = await _fileService.GetById(id);
            return Ok(result);
        }

        //[HttpPost("create-file")]
        //public async Task<IActionResult> CreateFile(IFormFile file)
        //{
        //    if (file.Length > 0)
        //    {
        //        byte[] fileInByteArray;

        //        using (var ms = new MemoryStream())
        //        {
        //            file.CopyTo(ms);
        //            fileInByteArray = ms.ToArray();
        //        }

        //        var outputFileInfo = await _fileService.CreateFile(fileInByteArray, FileFormat.HTML);

        //        var createdFile = await _fileService.GetById(outputFileInfo.FileId);
        //        if (createdFile == null)
        //            return StatusCode(StatusCodes.Status500InternalServerError);

        //        return Ok(outputFileInfo);
        //    }
        //    else
        //    {
        //        return BadRequest("There is no file added");
        //    }
        //}

        [HttpPost("create-file-in-directory")]
        public async Task<IActionResult> CreateFileInDirectory(IFormFile file)
        {
            if (file.Length > 0)
            {
                byte[] fileInByteArray;

                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileInByteArray = ms.ToArray();
                }

                var originPath = Path.Combine(Directory.GetCurrentDirectory(), "origins");
                //if (!Directory.Exists(originPath))
                //    Directory.CreateDirectory(originPath);

                var fileName = $"created_{DateTime.Now.ToFullString()}";

                var outputFileInfo = await _fileService.CreateFile(fileInByteArray, originPath, fileName, FileFormat.HTML);

                var createdFile = await _fileService.GetById(outputFileInfo.FileId);
                if (createdFile == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);

                return Ok(outputFileInfo);
            }
            else
            {
                return BadRequest("There is no file added");
            }
        }
    }
}
