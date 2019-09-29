using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MakaleProject.Models;

namespace MakaleProject.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }
        public ArticleRepository()
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=Articles;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public async Task AddAsync(ArticleModel articleModel)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"Insert Into [dbo].[Article] ([Title], [Author], [PublicationPlace], [PublicationDate]) VALUES (@Title, @Author, @PublicationPlace, @PublicationDate)";
                await dbConnection.ExecuteAsync(query,articleModel);
            }
        }

        public async Task<IEnumerable<ArticleModel>> GetAllAsync()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"Select[Id], [Title], [Author], [PublicationPlace], [PublicationDate] FROM[dbo].[Article]";
                var articles = await dbConnection.QueryAsync <ArticleModel>(query);
                return articles;
            }
        }

        public async Task<ArticleModel> GetAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"Select [Id], [Title], [Author], [PublicationPlace], [PublicationDate] FROM [dbo].[Article] WHERE [Id] = @Id";
                var article = await dbConnection.QueryFirstOrDefaultAsync<ArticleModel>(query, new { @Id = id });
                return article;
            }
        }

        public async Task UpdateAsync(ArticleModel articleModel)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"Update [dbo].[Article] Set [Title] = @Title, [Author] = @Author, [PublicationPlace] = @PublicationPlace,[PublicationDate] = @PublicationDate WHERE [Id] = @Id ";
                await dbConnection.ExecuteAsync(query, articleModel);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"Delete From [dbo].[Article] Where [Id] = @Id";
                await dbConnection.ExecuteAsync(query,new { @Id =id});
            }
        }
    }
}
