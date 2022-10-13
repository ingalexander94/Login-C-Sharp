using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Login.Model.DAO
{
    class ConexionDB
    {

        private SqlConnection Conexion;

        public SqlConnection Connection()
        {
            Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            return Conexion;

        }
    }
}
