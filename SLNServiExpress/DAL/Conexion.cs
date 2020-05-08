using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class Conexion
    {
        const string conString = "User Id=serviexpress;Password=seba;Data Source=localhost:1521/xe;";
        //string conString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;

        public OracleConnection con = null;
        public Conexion()
        {
            con = new OracleConnection(conString);
        }

        public void Conectar()
        {
            
            con = new OracleConnection(conString);
            con.Open();
            Console.WriteLine("DAL: conectar");
        }
        public void desconectar()
        {
            try
            {
                con.Close();
            }
            catch(Exception ex)
            {
                con.Close();
                Console.WriteLine("Error BLL: " + ex.Message);

            }
            Console.WriteLine("DAL: desconectar");
        }


    }
}
