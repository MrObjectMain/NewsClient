using NewsClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.UnitOfWorks.Interfaces
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ISourceRepository Sources { get; }
    }
}
