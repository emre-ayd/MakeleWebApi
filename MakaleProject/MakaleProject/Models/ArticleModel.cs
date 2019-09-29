using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakaleProject.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title{get;set;}
        public string Author { get; set; }
        public string PublicationPlace { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
