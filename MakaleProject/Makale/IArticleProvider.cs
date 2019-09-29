using System;
using System.Collections.Generic;
using System.Text;

namespace Makale.Data
{
    public interface IArticleProvider
    {
        IEnumerable<Article> GetArticle();
    }
}
