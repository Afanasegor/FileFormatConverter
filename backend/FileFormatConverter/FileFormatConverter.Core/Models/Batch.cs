using FileFormatConverter.Core.Models.Common;
using FileFormatConverter.Core.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileFormatConverter.Core.Models
{
    public class Batch : BaseEntity
    {
        [Column("origin_file_id")]
        public Guid OriginFileId { get; set; }

        [Column("origin_file_name")]
        public string OriginFileName { get; set; }

        [Column("target_file_id")]
        public Guid TargetFileId { get; set; }

        [Column("converter_type")]
        public BatchConverterType ConverterType { get; set; } = BatchConverterType.UNKNOWN;

        [Column("process_status")]
        public ProcessStatus ProcessStatus { get; set; }
    }
}
