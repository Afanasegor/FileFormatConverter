using FileFormatConverter.Core.Interfaces.Repositories;
using FileFormatConverter.Core.Models;
using FileFormatConverter.Core.Models.Enums;
using FileFormatConverter.Services.Utils.Converters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileFormatConverter.WebApi.Controllers
{
    /// <summary>
    /// Stub for fast testing CRUDs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBaseRepository<Batch> _batchRepository;

        public BatchController(IBaseRepository<Batch> batchRepository)
        {
            _batchRepository = batchRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var batches = await _batchRepository.GetAllAsync();
            var result = batches.Select(x => CoreModelsConverter.ConvertToOutputModel(x)).ToList();
            return Ok(result);
        }

        [HttpPost("create-batch")]
        public async Task<IActionResult> CreateBatch()
        {
            var newBatch = new Batch()
            {
                Id = Guid.NewGuid(),
                OriginFileId = Guid.NewGuid(),
                ProcessStatus = ProcessStatus.Created
            };

            await _batchRepository.CreateAsync(newBatch);
            await _batchRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("update-batch")]
        public async Task<IActionResult> UpdateBatch(Batch batch)
        {
            await _batchRepository.UpdateAsync(batch);
            await _batchRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("delete-batch")]
        public async Task<IActionResult> DeleteBatch(Guid id)
        {
            var entity = await _batchRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return Ok($"Not found batch with id: {id}");
            }

            await _batchRepository.DeleteAsync(entity);
            await _batchRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllBatches()
        {
            var allBatches = await _batchRepository.GetAllAsync();
            if (allBatches == null || !allBatches.Any())
            {
                return Ok("No batches in db");
            }

            foreach (var batch in allBatches)
            {
                await _batchRepository.DeleteAsync(batch);
            }
            await _batchRepository.SaveAsync();
            return Ok();
        }
    }
}
