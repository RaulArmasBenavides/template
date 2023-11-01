using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppMVC06.DataBase
{
    public class Conexion
    {
        public static SqlConnection getConnection()
        {
            SqlConnection cn = new SqlConnection("server=.;database=neptuno;integrated security=true");
            return cn;
        }
    }
}
