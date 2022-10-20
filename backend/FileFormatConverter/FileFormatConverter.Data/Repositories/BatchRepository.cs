using FileFormatConverter.Core.Models;
using FileFormatConverter.Data.Context;
using System.Threading.Tasks;

namespace FileFormatConverter.Data.Repositories
{
    public class BatchRepository : BaseRepository<Batch>
    {
        public BatchRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
