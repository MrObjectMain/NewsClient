using NewsClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Interfaces
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
    }
}
