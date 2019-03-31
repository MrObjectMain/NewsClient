using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsClient.UnitOfWorks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services
{
    public class NewsService
    {
        private readonly string _apiNewsKey = "17e4f139baae40be981076543ab4297c";
        private readonly string _queryTemplate = "https://newsapi.org/v2/everything?q={0}&from={1}-{2}-{3}&sortBy=publishedAt&apiKey=17e4f139baae40be981076543ab4297c";
        private readonly DatabaseService _databaseService = new DatabaseService(new UnitOfWork(new ApplicationContext()));
        private readonly FileService _fileService = new FileService();

        public async Task<ObservableCollection<Article>> GetNewsByQuery(string query)
        {
            try
            {
                ArticlesResult articlesResult = null;
 
                using (var client = new HttpClient())
                {
                    DateTime date = DateTime.Today.AddMonths(-1);
                    var jsonString = await client.GetStringAsync(new Uri(string.Format(_queryTemplate, query, date.Year, date.Month, date.Day)));
                    articlesResult = JsonConvert.DeserializeObject<ArticlesResult>(jsonString);
                    if (articlesResult != null)
                    {
                        var result = new ObservableCollection<Article>(articlesResult.Articles.Take(3));
                        await _databaseService.Create(result);
                        await _fileService.Create(result);
                        return result;
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                TextLog.LogText($"{DateTime.Now} NewsService->GetNewsByQuery->Message: {ex.Message} \n StackTrace : /n {ex.StackTrace}");
                return null;
            }
        }

        public async Task<ObservableCollection<Article>> GetUkraineNews()
        {
            return await GetNewsByQuery("Украина");
        }

        public async Task<ObservableCollection<Article>> GetPolandNews()
        {
            return await GetNewsByQuery("Польша");
        }

        public async Task<ObservableCollection<Article>> GetEnglandNews()
        {
            return await GetNewsByQuery("Англия");
        }
    }
}
