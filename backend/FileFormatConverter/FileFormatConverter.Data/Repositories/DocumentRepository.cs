using FileFormatConverter.Core.Models;
using FileFormatConverter.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace FileFormatConverter.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document>
    {
        public DocumentRepository(ApplicationContext context) : base(context)
        {
        }

        //public override async Task<Document> CreateAsync(Document entity)
        //{
        //    if (!string.IsNullOrWhiteSpace(entity.FileHash))
        //    {
        //        // Check if this file already exists in db and return if it does
        //        var existingFile = await _context.Documents.FirstOrDefaultAsync(f => f.FileHash == entity.FileHash);
        //        if (existingFile != null)
        //            return existingFile;
        //    }

        //    var result = await base.CreateAsync(entity);
        //    return result;
        //}
    }
}
