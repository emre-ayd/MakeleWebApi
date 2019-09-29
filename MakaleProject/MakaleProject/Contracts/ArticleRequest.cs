using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleProject.Contracts
{
    public class ArticleRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationPlace{get;set;}
        public DateTime PublicationDate { get; set; }
    }
}
