using MakaleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleProject.Data
{
    public interface IArticleRepository
    {
        Task<ArticleModel> GetAsync(int id);
        Task<IEnumerable<ArticleModel>> GetAllAsync();
        Task AddAsync(ArticleModel articleModel);
        Task UpdateAsync(ArticleModel articleModel);
        Task DeleteAsync(int id);
    }
}
