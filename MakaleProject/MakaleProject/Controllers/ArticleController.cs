using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakaleProject.Bussiness;
using MakaleProject.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakaleProject.Controllers
{


    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleBussiness _articleBussiness;

        public ArticleController(IArticleBussiness articleBussiness)
        {
            _articleBussiness = articleBussiness;
        }
        [Route("Get")]
        [HttpGet]
        public async Task<ArticleResponse> Get(int? id)
        {
            if (id.HasValue)
                return await _articleBussiness.GetAsync(id.Value);
            else
                return await _articleBussiness.GetAsyncAll();
        }

        [ProducesResponseType(201)]
        [Route("Post")]
        [HttpPost]
        public async Task Post([FromBody] ArticleRequest articleRequest)
        {
            await _articleBussiness.AddAsync(articleRequest);
        }

        [Route("Put/{id}")]
        [HttpPut]
        public async Task Put(int id, [FromBody] ArticleRequest articleRequest)
        {
            articleRequest.Id = id;
            await _articleBussiness.UpdateAsync(articleRequest);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _articleBussiness.Delete(id);
        }
    }
}
