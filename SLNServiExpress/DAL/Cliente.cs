using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cliente
    {
        public Conexion conexion = Conexion.Instance;
        OracleCommand cmd = null;

        public string rutCliente { get; set; }
        public string nombre { get; set; }

        public string apellidos { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public int idUsuario { get; set; }
        public Cliente()
        {
            conexion.Conectar();
            conexion.desconectar();


        }

        public void AgregarCliente()
        {
            conexion.Conectar();
            cmd = new OracleCommand("AGREGARCLIENTE", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("RUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = rutCliente;
            cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = nombre;
            cmd.Parameters.Add("APELLIDOS", OracleDbType.Varchar2, ParameterDirection.Input).Value = apellidos;
            cmd.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = correo;
            cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = direccion;
            cmd.Parameters.Add("TELEFONO", OracleDbType.Int32, ParameterDirection.Input).Value = telefono;
            cmd.Parameters.Add("IDUSUARIO", OracleDbType.Int32, ParameterDirection.Input).Value = idUsuario;
            cmd.ExecuteNonQuery();
            conexion.desconectar();
            Console.WriteLine("DAL: se agrego cliente ");



        }

        public Cliente BuscarCliente(string rutcli)
        {
            conexion.Conectar();
            string query = "";

            Cliente encontrado = new Cliente();
            query = "SELECT * FROM cliente WHERE RUT_CLI ='{0}'";
            string parametros = string.Format(query, rutcli);
            cmd = new OracleCommand(parametros, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cliente cli = new Cliente();
                cli.rutCliente = reader.GetString(0);
                cli.nombre = reader.GetString(1);
                cli.apellidos = reader.GetString(2);
                cli.correo = reader.GetString(3);
                cli.direccion = reader.GetString(4);
                cli.telefono = reader.GetInt32(5);
                cli.idUsuario = reader.GetInt32(6);

            }
            conexion.desconectar();
            return encontrado;



        }


        public void EditarCliente()
        {
            conexion.Conectar();
            cmd = new OracleCommand("EditarCli", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("RUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = rutCliente;
            cmd.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = nombre;
            cmd.Parameters.Add("APELLIDOS", OracleDbType.Varchar2, ParameterDirection.Input).Value = apellidos;
            cmd.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = correo;
            cmd.Parameters.Add("DIRECCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = direccion;
            cmd.Parameters.Add("TELEFONO", OracleDbType.Int32, ParameterDirection.Input).Value = telefono;
            //cmd.Parameters.Add("IDUSUARIO", OracleDbType.Int32, ParameterDirection.Input).Value = idUsuario;
            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: se ha modificado el cliente");
            conexion.desconectar();
        }

        public string BuscarRut(string rutCli)
        {
            conexion.Conectar();
            string query;
            string result;

            query = "SELECT RUT_CLI FROM cliente WHERE RUT_CLI ='{0}'";
            string parametros = string.Format(query, rutCli);
            cmd = new OracleCommand(parametros, conexion.con);
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader(); //se ejecuta
            while (reader.Read())
            {
                rutCliente = reader.GetValue(0).ToString(); // asigna el resultado

            }
            result = rutCliente;
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


        public List<string> ListarRut()
        {
            conexion.Conectar();
            string query;
            string result;
            List<string> lista = new List<string>();
            query = "SELECT RUT_CLI FROM cliente";
            cmd = new OracleCommand(query, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetValue(0).ToString();
                lista.Add(result);

            }
            conexion.desconectar();
            return lista;




        }

        public List<Cliente> listar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARCLIENTES", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Cliente> lista = new List<Cliente>();

            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Cliente cli = new Cliente();
                cli.rutCliente = reader.GetString(0);
                cli.nombre = reader.GetString(1);
                cli.apellidos = reader.GetString(2);
                cli.correo = reader.GetString(3);
                cli.telefono = int.Parse(reader.GetValue(4).ToString());
                cli.direccion = reader.GetString(5);
                cli.idUsuario = int.Parse(reader.GetValue(6).ToString());

                lista.Add(cli);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;



        }
    }
}
