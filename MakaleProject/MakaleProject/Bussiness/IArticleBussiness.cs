using MakaleProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleProject.Bussiness
{
    public interface IArticleBussiness
    {
        Task<ArticleResponse> GetAsync(int id);
        Task<ArticleResponse> GetAsyncAll();
        Task AddAsync(ArticleRequest articleRequest);
        Task UpdateAsync(ArticleRequest articleRequest);
        Task Delete(int id);
    }
}
