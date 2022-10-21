using FileFormatConverter.Core.Interfaces.Repositories;
using FileFormatConverter.Core.Models;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Input;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using FileFormatConverter.Services.Utils.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Business
{
    public class BatchService : IBatchService
    {
        private readonly IBaseRepository<Batch> _batchRepository;

        public BatchService(IBaseRepository<Batch> batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<OutputBatchModel> CreateBatch(InputFileInfo originFileInfo)
        {
            if (!File.Exists(originFileInfo.FilePath))
                throw new ArgumentException("File doesn't exist");

            // TODO: create file before and add id of file to batch
            var newBatch = new Batch()
            {
                Id = Guid.NewGuid(),
                ProcessStatus = Core.Models.Enums.ProcessStatus.Created,
                OriginFileId = originFileInfo.Id,
                ConverterType = originFileInfo.ConverterType.ConvertToCore(),
                OriginFileName = originFileInfo.FileName
            };

            var result = await _batchRepository.CreateAsync(newBatch);
            await _batchRepository.SaveAsync();

            var output = CoreModelsConverter.ConvertToOutputModel(result);
            return output;
        }

        public async Task ChangeStatus(Guid id, ProcessStatus status)
        {
            var batchToUpdate = await _batchRepository.GetByIdAsync(id);
            
            if (batchToUpdate == null)
                throw new ArgumentNullException($"Batch with id ({id}) doesn't exist");

            batchToUpdate.ProcessStatus = CoreModelsConverter.ConvertToCore(status);
            await _batchRepository.UpdateAsync(batchToUpdate);
            await _batchRepository.SaveAsync();
        }

        public async Task<IList<OutputBatchModel>> GetBatchesByProcessStatus(ProcessStatus status)
        {
            var coreStatus = CoreModelsConverter.ConvertToCore(status);

            var batches = await _batchRepository.GetAllAsync();
            var result = batches.Where(b => b.ProcessStatus == coreStatus).ToList();

            var output = result.Select(x => CoreModelsConverter.ConvertToOutputModel(x)).ToList();
            return output;
        }

        public async Task<OutputBatchModel> GetBatchById(Guid batchId)
        {
            var batch = await _batchRepository.GetByIdAsync(batchId);
            var result = batch.ConvertToOutputModel();
            return result;
        }

        public async Task AddTargetFileInfoToBatch(Guid batchId, InputFileInfo targetFileInfo)
        {
            var batchToUpdate = await _batchRepository.GetByIdAsync(batchId);

            batchToUpdate.TargetFileId = targetFileInfo.Id;
            await _batchRepository.UpdateAsync(batchToUpdate);
            await _batchRepository.SaveAsync();
        }
    }
}
