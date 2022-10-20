using FileFormatConverter.Core.Models.Enums;

namespace FileFormatConverter.Core.Interfaces.Common.Models
{
    public interface IFile
    {   
        public FileFormat FileFormat { get; set; }
    }
}
