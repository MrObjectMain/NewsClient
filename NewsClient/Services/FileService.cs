using NewsAPI.Models;
using NewsClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services
{
    public class FileService : IBaseService
    {
        private readonly string _writePath = $"{Directory.GetCurrentDirectory()}\\articles.txt";
        public async Task Create(ObservableCollection<Article> articles)
        {
            var _articles = articles.Select(article => new Models.Article()
            {
                Author = article.Author,
                Description = article.Description,
                PublishedAt = article.PublishedAt,
                Source = new Models.Source()
                {
                    Id = article.Source.Id,
                    Name = article.Source.Name
                },
                Title = article.Title,
                Url = article.Url,
                UrlToImage = article.UrlToImage
            }).ToList();

            using (StreamWriter streamWriter = new StreamWriter(_writePath, true, Encoding.Default))
            {
                foreach (var article in _articles)
                    await streamWriter.WriteLineAsync(article.ToString());
            }
        }
    }
}
