using NewsAPI.Models;
using NewsClient.Services.Interfaces;
using NewsClient.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services
{
    public class DatabaseService : BaseService, IBaseService
    {
        public DatabaseService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task Create(ObservableCollection<Article> articles)
        {
            await _database.Articles.Create(articles.Select(article => new Models.Article()
            {
                Author = article.Author,
                Description = article.Description,
                PublishedAt = article.PublishedAt,
                Source = new Models.Source()
                {
                    Name = article.Source.Name
                },
                Title = article.Title,
                Url = article.Url,
                UrlToImage = article.UrlToImage
            }).ToList());
        }
    }
}
