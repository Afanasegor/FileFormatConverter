using CoreModels = FileFormatConverter.Core.Models;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using System;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;

namespace FileFormatConverter.Services.Utils.Converters
{
    public static class CoreModelsConverter
    {
        public static CoreModels.Enums.ProcessStatus ConvertToCore(this ProcessStatus status)
        {
            switch (status)
            {
                case ProcessStatus.Created:
                    return CoreModels.Enums.ProcessStatus.Created;
                case ProcessStatus.InProgress:
                    return CoreModels.Enums.ProcessStatus.InProgress;
                case ProcessStatus.Error:
                    return CoreModels.Enums.ProcessStatus.Error;
                case ProcessStatus.Completed:
                    return CoreModels.Enums.ProcessStatus.Completed;
                default:
                    throw new ArgumentException("Can't convert to core model", "status");
            }
        }
        public static ProcessStatus ConvertToServiceProcessStatus(this CoreModels.Enums.ProcessStatus status)
        {
            switch (status)
            {
                case CoreModels.Enums.ProcessStatus.Created:
                    return ProcessStatus.Created;
                case CoreModels.Enums.ProcessStatus.InProgress:
                    return ProcessStatus.InProgress;
                case CoreModels.Enums.ProcessStatus.Error:
                    return ProcessStatus.Error;
                case CoreModels.Enums.ProcessStatus.Completed:
                    return ProcessStatus.Completed;
                default:
                    throw new ArgumentException("Can't convert to service model", "status");
            }
        }

        public static OutputBatchModel ConvertToOutputModel(this CoreModels.Batch batch)
        {
            var result = new OutputBatchModel()
            {
                Id = batch.Id,
                OriginFileId = batch.OriginFileId,
                TargetFileId = batch.TargetFileId,
                ConverterType = batch.ConverterType.ConvertToServiceType(),
                ProcessStatus = ConvertToServiceProcessStatus(batch.ProcessStatus)
            };
            return result;
        }
        
        public static FileFormat ConvertToServiceFileFormat(this CoreModels.Enums.FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case CoreModels.Enums.FileFormat.HTML:
                    return FileFormat.HTML;
                case CoreModels.Enums.FileFormat.PDF:
                    return FileFormat.PDF;
                default:
                    return FileFormat.UNKNOWN;
            }
        }

        public static CoreModels.Enums.FileFormat ConvertToCore(this FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.HTML:
                    return CoreModels.Enums.FileFormat.HTML;
                case FileFormat.PDF:
                    return CoreModels.Enums.FileFormat.PDF;
                default:
                    return CoreModels.Enums.FileFormat.UNKNOWN;
            }
        }

        public static ConverterType ConvertToServiceType(this CoreModels.Enums.BatchConverterType converterType)
        {
            switch (converterType)
            {
                case CoreModels.Enums.BatchConverterType.HTML_TO_PDF:
                    return ConverterType.HTML_TO_PDF;
                default:
                    return ConverterType.UNKNOWN;
            }
        }

        public static CoreModels.Enums.BatchConverterType ConvertToCore(this ConverterType converterType)
        {
            switch (converterType)
            {
                case ConverterType.HTML_TO_PDF:
                    return CoreModels.Enums.BatchConverterType.HTML_TO_PDF;
                default:
                    return CoreModels.Enums.BatchConverterType.UNKNOWN;
            }
        }
    }
}
