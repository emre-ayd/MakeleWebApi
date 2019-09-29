using MakaleProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleProject.Contracts
{
    public class ArticleResponse
    {
        public ArticleResponse()
        {
            Articles = new List<ArticleModel>();
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public List<ArticleModel> Articles { get; }
    }
}
