using Makete.Webshop.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Makete.Webhop.UnitTesting
{
    public class SqlTests
    {
        private readonly IConfiguration _configuration;

        public SqlTests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Testing.json", true);

            _configuration = builder.Build();

        }
        [Fact]

        public void TestSql_Connection_Failed()
        {
            var connection = new SqlConnection(string.Empty);
            connection.Open();
            connection.Close();

            connection.Dispose();
        }

        [Fact]

        public void TestSql_Connection_Sucess()
        {
            var connection = new SqlConnection("Data Source =.; Initial Catalog = WebshopDB; Integrated Security = True; TrustServerCertificate = True;") ;
            
            connection.Open();
            Console.WriteLine("Connection successful!");
            connection.Close();
            
        }

        [Fact]

        public void TestSql_ConnectionScoped_Sucess()
        {
            using var connection = new SqlConnection("Data Source =.; Initial Catalog = WebshopDB; Integrated Security = True; TrustServerCertificate = True;");

            connection.Open();
                      
        }

        [Fact]
        public void TestSql_ConnectionNewer_Success()
        {
            using var connection = new SqlConnection("Server =.; Database = WebshopDB; Integrated Security = True; TrustServerCertificate = True;");

            connection.Open();
        }

        [Fact]
        public void TestSql_ConnectionSql_Failed()
        {
            using var connection = new SqlConnection("Server =.; Database = WebshopDB; Integrated Security = True;User ID=sa;Password=davor123; TrustServerCertificate = True;");

            connection.Open();
        }

        [Fact]
        public void TestSql_ConnectionConfiguration_Success()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            connection.Open();
        }

        [Fact]
        public void TestSql_NonQueryCommand_Success()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            var command = new SqlCommand($"SELECT 1", connection);

            connection.Open();

            var result = command.ExecuteNonQuery();

            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestSql_ScalarCommand_Success()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand($"SELECT 1", connection);

            connection.Open();

            var result = command.ExecuteScalar();

            Assert.Equal(1, result);
        }

        [Fact] 
        public void TestSql_DataReaderCommand_Success()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand($"SELECT * FROM ScaleModels", connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                reader.GetInt32("Id");

                Console.Write($"Id: {reader["Id"]}, ");
                Console.Write($"Name: {reader["Name"]}, ");
                Console.Write($"BrandId: {reader["BrandId"]}, ");
                Console.Write($"Category: {reader["Category"]}, ");
                Console.Write($"Scale: {reader["Scale"]}, ");
                Console.Write($"AmountAvailable: {reader["AmountAvailable"]}, ");
                Console.Write($"Price: {reader["Price"]}, ");

            }
        }


        [Fact]
        public void TestSql_DataReaderCommand_GetAll()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand($"SELECT * FROM ScaleModels", connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            var result = new List<ScaleModel>();

            while (reader.Read())
            {
                result.Add(new ScaleModel()
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name")
                });
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(10, result.Count);
        }

        [Fact] //Fejla
        public void TestSql_DataReaderCommand_GetById()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection(connectionString);

            using var command = new SqlCommand($"SELECT * FROM ScaleModels WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", 3);

            connection.Open();

            using var reader = command.ExecuteReader();

            var result = new List<ScaleModel>();

            while (reader.Read())
            {
                result.Add(new ScaleModel()
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name")
                });
            }

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
    }
}
