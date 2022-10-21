using FileFormatConverter.Core.Interfaces.Repositories;
using FileFormatConverter.Core.Models;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using FileFormatConverter.Services.Utils.Converters;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Business
{
    public class DocumentService : IFileService
    {
        private readonly IBaseRepository<Document> _documentRepository;

        public DocumentService(IBaseRepository<Document> documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<OutputFileInfo> GetById(Guid id)
        {
            var outputResult = new OutputFileInfo();

            var result = await _documentRepository.GetByIdAsync(id);
            if (result == null)
                return outputResult;

            outputResult.FileId = result.Id;
            outputResult.FilePath= result.FilePath;

            return outputResult;
        }

        [Obsolete]
        public async Task<OutputFileInfo> CreateRecordOfFile(string fullPath, FileFormat fileFormat)
        {
            var result = new OutputFileInfo();

            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentException("Problem with one of parameters (fullPath)");

            if (!File.Exists(fullPath))
                throw new ArgumentException("File doesn't exist");

            var fileName = fullPath.Split(@"\").LastOrDefault();

            var document = new Document()
            {
                Id = Guid.NewGuid(),
                FilePath = fullPath,
                FileName = fileName,
                FileFormat = fileFormat.ConvertToCore(),
            };

            var createdTargetFile = await _documentRepository.CreateAsync(document);
            await _documentRepository.SaveAsync();

            result.FileId = createdTargetFile.Id;
            result.FilePath = createdTargetFile.FilePath;

            return result;
        }


        /// <param name="path">Path - where to save</param>
        /// <returns></returns>
        //public async Task<OutputFileInfo> CreateFile(byte[] blob, FileFormat fileFormat)
        //{
        //    var result = new OutputFileInfo();

        //    try
        //    {
        //        //var filePath = await SaveFileAsync(blob, fileFormat.ConvertToString());
        //        if (blob == null || blob.Length == 0)
        //            throw new ArgumentException("Input file is empty");

        //        var fileHash = Sha1HashFile(blob);
        //        var fileLength = blob.Length;
        //        var document = new Document()
        //        {
        //            Id = Guid.NewGuid(),
        //            File = blob,
        //            FileHash = fileHash,
        //            FileLength = fileLength,
        //            FileFormat = fileFormat.ConvertToCore(),
        //        };

        //        var createdFile = await _documentRepository.CreateAsync(document);
        //        await _documentRepository.SaveAsync();

        //        result.FileId = createdFile.Id;
        //        result.FileBlob = document.File;

        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        // TODO: add logs
        //        throw;
        //    }
        //}

        private static string Sha1HashFile(byte[] file)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(file)).Replace("-", "");
            }
        }

        /// <summary>
        /// Save file on disk
        /// </summary>
        /// <param name="path">Where to save</param>
        /// <param name="mime">FileFormat in string format</param>
        /// <returns>File full path</returns>
        private async Task<string> SaveFileAsync(byte[] blob, string path, string fileName, string mime)
        {
            try
            {
                var result = string.Empty;

                if (blob == null || blob.Length == 0)
                    throw new ArgumentException("There is no blob");

                if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(mime))
                    throw new ArgumentException("Problem with one of parameters (path | fileName | mime)");

                var fileNameWithMime = fileName + mime;

                // Check for dots in fileNameWithMime (using regex)
                var normalizedFileName = Regex.Replace(fileNameWithMime, @"/.+", ".");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            
                var fullPath = Path.Combine(path, normalizedFileName);

                await File.WriteAllBytesAsync(fullPath, blob);

                result = fullPath;
                return result;
            }
            catch (ArgumentException)
            {
                // TODO: add logging
                throw;
            }
            catch (Exception)
            {
                // TODO: add logging
                throw;
            }
        }

        public async Task<OutputFileInfo> CreateFile(byte[] blob, string path, string fileName, FileFormat fileFormat)
        {
            var result = new OutputFileInfo();

            try
            {
                var filePath = await SaveFileAsync(blob, path, fileName, fileFormat.ConvertToString());
                if (blob == null || blob.Length == 0)
                    throw new ArgumentException("Input file is empty");

                var fileHash = Sha1HashFile(blob);
                var fileLength = blob.Length;
                var document = new Document()
                {
                    Id = Guid.NewGuid(),
                    FilePath = filePath,
                    FileHash = fileHash,
                    FileName = fileName,
                    FileFormat = fileFormat.ConvertToCore(),
                };

                var createdFile = await _documentRepository.CreateAsync(document);
                await _documentRepository.SaveAsync();

                result.FileId = createdFile.Id;
                result.FilePath = createdFile.FilePath;
                result.FileHash = createdFile.FileHash;

                return result;
            }
            catch (Exception ex)
            {
                // TODO: add logs
                throw;
            }
        }
    }
}
