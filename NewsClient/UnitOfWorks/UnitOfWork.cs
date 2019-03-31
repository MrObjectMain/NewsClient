using NewsClient.Interfaces;
using NewsClient.Repositories;
using NewsClient.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.UnitOfWorks
{
    public class UnitOfWork : IBaseUnitOfWork
    {
        private ApplicationContext _dataBase;
        private ArticleRepository _articleRepository;
        private SourceRepository _sourceRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _dataBase = context;
        }
        public IArticleRepository Articles
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_dataBase);
                }
                return _articleRepository;
            }
        }

        public ISourceRepository Sources
        {
            get
            {
                if (_sourceRepository == null)
                {
                    _sourceRepository = new SourceRepository(_dataBase);
                }
                return _sourceRepository;
            }
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                    _dataBase = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
