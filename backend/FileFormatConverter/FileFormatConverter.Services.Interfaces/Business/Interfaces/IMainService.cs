using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IMainService
    {
        Task<Guid> StartConverting(byte[] file, ConverterType converterType, string fileName);
    }
}
