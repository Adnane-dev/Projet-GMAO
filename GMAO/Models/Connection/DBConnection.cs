using ServerTemplateAPI.Utilities;
using System.Data.SqlClient;

namespace ServerTemplateAPI.Models.Connection
{
    public class DBConnection
    {
        //;Encrypt=False
        static string ConnectionString = "Data Source=DESKTOP-K8IAMOO\\SQLEXPRESS01;Initial Catalog=GMAO_DB;Integrated Security=True;";
        //static string ConnectionString = "Data Source=DESKTOP-K8IAMOO\\SQLEXPRESS01;Encrypt=False;Initial Catalog=ArticleDB;TrustServerCertificate=True;";
        //  "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ArticleDB;Data Source=DESKTOP-EXPRESS01";
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new MyException(ex, "Database Connection Error", ex.Message, "Connection");
            }
        }
    }
}
