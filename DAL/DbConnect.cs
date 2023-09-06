using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DbConnect
    {
        static string connstr = "Data Source=ADMIN;Initial Catalog=SalesManagement;Integrated Security=True";
        protected SqlConnection _conn = new SqlConnection(connstr);
    }
}
