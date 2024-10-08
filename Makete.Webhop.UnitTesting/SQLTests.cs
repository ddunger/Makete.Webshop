using Microsoft.Data.SqlClient;

namespace Makete.Webhop.UnitTesting
{
    public class SQLTests
    {
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
            var connection = new SqlConnection("Data Source =.; Initial Catalog = book_library; Integrated Security = True; TrustServerCertificate = True;") ;
            
            connection.Open();
            Console.WriteLine("Connection successful!");
            connection.Close();
            
        }

        [Fact]

        public void TestSql_ConnectionScoped_Sucess()
        {
            using var connection = new SqlConnection("Data Source =.; Initial Catalog = book_library; Integrated Security = True; TrustServerCertificate = True;");

            connection.Open();
                      
        }
    }
}
