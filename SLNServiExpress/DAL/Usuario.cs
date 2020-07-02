using Microsoft.SqlServer.Server;
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
    public class Usuario
    {
        public Conexion conexion = Conexion.Instance;
        OracleCommand cmd = null;

        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }

        public Usuario()
        {
            
            conexion.Conectar();
            conexion.desconectar();
        }
        public void AgregarUsuario(string nombreUsuario, string contrasena, string rol)
        {
            if (string.IsNullOrEmpty(buscarId(nombreUsuario)))
            {
                conexion.Conectar(); // se conecta a la base de datos
                cmd = new OracleCommand("AGREGARUSER", conexion.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("NOMBREUSUARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = nombreUsuario;
                cmd.Parameters.Add("CONTRA", OracleDbType.Varchar2, ParameterDirection.Input).Value = contrasena;
                cmd.Parameters.Add("ROLUSER", OracleDbType.Varchar2, ParameterDirection.Input).Value = rol;

                cmd.ExecuteNonQuery();

                Console.WriteLine("DAL: procedimiento");
                conexion.desconectar();
            }
            else
            {
                throw  new Exception("El Nombre de usuario ya existe!" );
            }
            
            
        }

        public string TryLogin(string nombreUsuario, string contrasena)
        {
            cmd = null; 
            conexion.Conectar(); // se conecta a la base de datos
            
            try
            {
                string query = "";
                string result = "";
                query = "SELECT AUTH_USER('{0}','{1}') FROM usuario WHERE nombre_usuario ='{2}'"; // se crea la consulta
                string parametros = string.Format(query ,nombreUsuario,contrasena,nombreUsuario);  // se le asigan los parametros
                cmd = new OracleCommand(parametros, conexion.con); 
                
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader(); //se ejecuta
                while (reader.Read())
                {
                    result = reader.GetValue(0).ToString(); // asigna el resultado
                }
                
                switch (result)
                {
                    case "true":
                        conexion.desconectar();
                        return result;

                    case "false":
                        conexion.desconectar();
                        return result;

                    default:
                        conexion.desconectar();
                        return "Error";
                }


            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: "+ex.Message);
                conexion.desconectar();
                return "Error";
            }

           
        }

        public string rolUsuario(string nombreUsuario)
        { // lo mismo que TryLogin
            cmd = null;
            conexion.Conectar();
            string query = "";
            try
            {
                string result = "";
                query = "select GET_ROL('{0}') FROM usuario where nombre_usuario ='{0}'";
                string parametros = string.Format(query, nombreUsuario);
                Console.WriteLine(parametros);
                cmd = new OracleCommand(parametros, conexion.con);
                cmd.CommandType = CommandType.Text;

                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetValue(0).ToString();
                }
                switch (result)
                {
                    case "adm":
                        conexion.desconectar(); 
                        return result;

                    case "emp":
                        conexion.desconectar(); 
                        return result;

                    case "cli":
                        conexion.desconectar();
                        return result;

                    default:
                        conexion.desconectar(); 
                        return "Error";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getRol: " + ex.Message);
                conexion.desconectar(); 
                return "Error";
            }
            
        }
        public List<Usuario> listar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARUSUARIO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Usuario> lista = new List<Usuario>();

            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Usuario us = new Usuario();
                us.idUsuario = int.Parse(reader.GetValue(0).ToString());
                us.nombreUsuario = reader.GetString(1);

                lista.Add(us);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;
        }

        public string buscarId(string nombreUser)
        {
            cmd = null;
            conexion.Conectar();
            string query = "";
            try
            {
                string result = "";
                query = "select ID_USUARIO FROM usuario where nombre_usuario ='{0}'";
                string parametros = string.Format(query, nombreUser);
                Console.WriteLine(parametros);
                cmd = new OracleCommand(parametros, conexion.con);
                cmd.CommandType = CommandType.Text;

                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetValue(0).ToString(); // asigna el resultado
                }
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error: "+ex.Message);
                return string.Empty;
            }


        }

    }
}   
