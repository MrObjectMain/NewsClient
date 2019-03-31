using NewsClient.Interfaces;
using NewsClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Repositories
{
    public class SourceRepository : BaseRepository<Source>, ISourceRepository
    {
        public SourceRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
