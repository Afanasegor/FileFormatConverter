using FileFormatConverter.Core.Interfaces.Common.Models;
using FileFormatConverter.Core.Models.Common;
using FileFormatConverter.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileFormatConverter.Core.Models
{
    public class Document : BaseEntity, IFile, IFileOnDisk
    {

        [Column("file_format")]
        public FileFormat FileFormat { get; set; } = FileFormat.UNKNOWN;
        
        [Column("file_hash")]
        public string FileHash { get; set; }

        [Column("file_path")]
        public string FilePath { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }
    }
}
