using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FileFormatConverter.Services.Fabrics
{
    public class FileConverterFactory : IFileConverterFactory
    {
        private readonly IEnumerable<IFileConverter> _fileConverters;

        public FileConverterFactory(IEnumerable<IFileConverter> fileConverters)
        {
            _fileConverters = fileConverters;
        }

        public IFileConverter GetFileConverter(ConverterType converterType)
        {
            return _fileConverters.SingleOrDefault(x => x.ConverterType == converterType);
        }
    }
}
