using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleProject.Contracts;
using MakaleProject.Data;
using MakaleProject.Models;

namespace MakaleProject.Bussiness
{
    public class ArticleBussiness : IArticleBussiness
    {
        private IArticleRepository _articleRepository;

        public ArticleBussiness(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task AddAsync(ArticleRequest articleRequest)
        {
            ArticleModel articleModel = new ArticleModel()
            {
                Title = articleRequest.Title,
                Author = articleRequest.Author,
                PublicationDate = articleRequest.PublicationDate,
                PublicationPlace = articleRequest.PublicationPlace
            };
            await _articleRepository.AddAsync(articleModel);    
        }

        public async Task Delete(int id)
        {
            await _articleRepository.DeleteAsync(id);
        }

        public async Task<ArticleResponse> GetAsync(int id)
        {
            ArticleResponse articleResponse = new ArticleResponse();
            var article = await _articleRepository.GetAsync(id);
            if(article == null)
            {
                articleResponse.Message = "Makale Bulunamadı";
            }
            else
            {
                articleResponse.Articles.Add(article);
            }
            return articleResponse;
        }

        public async Task<ArticleResponse> GetAsyncAll()
        {
            ArticleResponse articleResponse = new ArticleResponse();
            IEnumerable<ArticleModel> articles = await _articleRepository.GetAllAsync();
            if(articles.ToList().Count==0)
            {
                articleResponse.Message = "Makele Listesi Bulunamadı";
            }
            else
            {
                articleResponse.Articles.AddRange(articles);
            }
            return articleResponse;
        }

        public async Task UpdateAsync(ArticleRequest articleRequest)
        {
            ArticleModel articleModel = new ArticleModel()
            {
               
                Id = articleRequest.Id,
                Title = articleRequest.Title,
                Author = articleRequest.Author,
                PublicationDate = articleRequest.PublicationDate,
                PublicationPlace = articleRequest.PublicationPlace
            };
            await _articleRepository.UpdateAsync(articleModel);
        }
    }
}
