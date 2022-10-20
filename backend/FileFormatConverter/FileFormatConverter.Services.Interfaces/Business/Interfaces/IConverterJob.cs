using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IConverterJob
    {
        Task ConvertByBatchIdAsync(Guid batchId);
    }
}
