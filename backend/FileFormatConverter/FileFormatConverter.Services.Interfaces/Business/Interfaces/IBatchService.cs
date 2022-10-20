using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Input;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IBatchService
    {
        Task<OutputBatchModel> CreateBatch(InputFileInfo originFileInfo);

        /// <param name="id">Batch id</param>
        /// <param name="status">Required status</param>
        Task ChangeStatus(Guid id, ProcessStatus status);
        Task<IList<OutputBatchModel>> GetBatchesByProcessStatus(ProcessStatus status);
        Task<OutputBatchModel> GetBatchById(Guid batchId);
        Task AddTargetFileInfoToBatch(Guid batchId, InputFileInfo targetFileInfo);
    }
}
