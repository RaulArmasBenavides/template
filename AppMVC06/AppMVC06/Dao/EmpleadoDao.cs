using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AppMVC06.Models;
using AppMVC06.DataBase;

namespace AppMVC06.Dao
{
    public class EmpleadoDao
    {
        public Empleado validar(string usuario, string password)
        {
            Empleado emp = null;
            try
            {
                using (var cn = Conexion.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("usp_Empleado_valida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        emp = new Empleado()
                        {
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            Apellidos = dr["Apellidos"].ToString(),
                            Nombre = dr["Nombre"].ToString()
                        };

                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }
    }
}
