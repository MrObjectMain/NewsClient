using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Services.Interfaces
{
    public interface IBaseService
    {
        Task Create(ObservableCollection<Article> articles);
    }
}
