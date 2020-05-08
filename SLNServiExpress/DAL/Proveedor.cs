using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class Proveedor
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;

        public string RutProveedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Rubro { get; set; }


        public Proveedor()
        {
            conexion.Conectar();
            conexion.desconectar();
        }

        public void AgregarProveedor()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("agregarprov", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("RUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutProveedor;
            cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = Nombre;
            cmd.Parameters.Add("APELLIDO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Apellido;
            cmd.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Correo;
            cmd.Parameters.Add("TEL", OracleDbType.Int32, ParameterDirection.Input).Value = Telefono;
            cmd.Parameters.Add("RUBRO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Rubro;

            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: Se agregó proveedor");
            conexion.desconectar(); // se desconecta a la base de datos
        }

        public Proveedor BuscarProveedor(string rutPro)
        {
            conexion.Conectar(); // se conecta a la base de datos
            string query = "";

            Proveedor encontrado = new Proveedor();
            query = "SELECT * FROM proveedor WHERE RUT_PROVEEDOR ='{0}'"; // se crea la consulta
            string parametros = string.Format(query, rutPro);  // se le asigan los parametros
            cmd = new OracleCommand(parametros, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader(); //se ejecuta
            while (reader.Read())
            {
                Proveedor pro = new Proveedor();
                pro.RutProveedor = reader.GetString(0);
                pro.Nombre = reader.GetString(1);
                pro.Apellido = reader.GetString(2);
                pro.Correo = reader.GetString(3);
                pro.Telefono = reader.GetInt32(4);
                pro.Rubro = reader.GetString(5);
                encontrado = pro;
            }
            conexion.desconectar(); // se desconecta a la base de datos
            return encontrado;
           
           
        }

        public void EditarProveedor()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("EDITARPROV", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = Nombre;
            cmd.Parameters.Add("APELLIDO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Apellido;
            cmd.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Correo;
            cmd.Parameters.Add("TEL", OracleDbType.Int32, ParameterDirection.Input).Value = Telefono;
            cmd.Parameters.Add("RUBRO", OracleDbType.Varchar2, ParameterDirection.Input).Value = Rubro;
            cmd.Parameters.Add("RUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutProveedor;

            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: Se Modificó proveedor");
            conexion.desconectar(); // se desconecta a la base de datos
        }

        public string BuscarRut(string rutPro)
        {
            conexion.Conectar(); // se conecta a la base de datos
            string query;
            string result;

            query = "SELECT RUT_PROVEEDOR FROM proveedor WHERE RUT_PROVEEDOR ='{0}'"; // se crea la consulta
            string parametros = string.Format(query, rutPro);  // se le asigan los parametros
            cmd = new OracleCommand(parametros, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader(); //se ejecuta
            while (reader.Read())
            {
                RutProveedor = reader.GetValue(0).ToString(); // asigna el resultado
  
            }
            result = RutProveedor;
            if (!string.IsNullOrEmpty(result))
            {
                conexion.desconectar(); // se desconecta a la base de datos
                return result;
            }
            else
            {
                conexion.desconectar(); // se desconecta a la base de datos
                return string.Empty;
            }
        }

        public List<Proveedor> listar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARPROVEEDORES", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Proveedor> lista = new List<Proveedor>();

            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();
 
            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Proveedor pro = new Proveedor();
                pro.RutProveedor = reader.GetString(0);
                pro.Nombre = reader.GetString(1);
                pro.Apellido = reader.GetString(2);
                pro.Correo = reader.GetString(3);
                pro.Telefono = int.Parse(reader.GetValue(4).ToString());
                pro.Rubro = reader.GetString(5);


                lista.Add(pro);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;
        }

        public List<string> ListarRut()
        {
            conexion.Conectar(); // se conecta a la base de datos
            string query;
            string result;
            List<string> lista = new List<string>();
            query = "SELECT RUT_PROVEEDOR FROM proveedor"; // se crea la consulta
            cmd = new OracleCommand(query, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader(); //se ejecuta
            while (reader.Read())
            {
                result = reader.GetValue(0).ToString(); // asigna el resultado
                lista.Add(result);

            }
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;

        }
    }
}
