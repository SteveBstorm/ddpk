using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using WebApplication1.Models;

namespace WebApplication1.DALServices
{
    public class MovieService
    {
        private SqlConnection _connection;

        public MovieService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Movie> GetAll()
        {
            string sql = "SELECT * FROM Movie";

            return _connection.Query<Movie>(sql).ToList();
        }

        public Movie Get(int id)
        {
            string sql = "SELECT * FROM Movie WHERE Id = @id";
            return _connection.QueryFirst<Movie>(sql, new {id});
        }

        public void Create(Movie movie)
        {
            string sql = "INSERT INTO Movie (Titre, Description, Real) " +
                "VALUES (@Titre, @Description, @Real)";

            _connection.Execute(sql, movie);
        }
    }
}
