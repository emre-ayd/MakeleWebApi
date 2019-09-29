using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
namespace Makale.Data
{
    public class ArticleProvider : IArticleProvider
    {
        private readonly string connectionString;

        public ArticleProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Article> GetArticle()
        {
            IEnumerable<Article> article = null;

            using (var connection =new SqlConnection(connectionString))
            {
                article = connection.Query<Article>("select Id, Title, Author, PublicationPlace, PublicationDate from Article");
            }
            return article;
        }
    }
}
