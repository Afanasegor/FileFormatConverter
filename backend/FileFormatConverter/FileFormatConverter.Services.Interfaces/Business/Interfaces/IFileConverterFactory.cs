using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFormatConverter.Services.Interfaces.Business.Interfaces
{
    public interface IFileConverterFactory
    {
        IFileConverter GetFileConverter(ConverterType converterType);
    }
}
