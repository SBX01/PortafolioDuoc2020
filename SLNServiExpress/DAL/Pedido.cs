
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
    public class Pedido
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;

        #region Variables y Propiedades
        DateTime fecha;
        string descripcion;
        string rutEmpleado;
        string rutProveedor;

        public int IdPedido { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string RutEmpleado { get => rutEmpleado; set => rutEmpleado = value; }
        public string RutProveedor { get => rutProveedor; set => rutProveedor = value; }
        #endregion

        public Pedido()
        {

        }

        public void agregar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_AGREGARPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("FECHA", OracleDbType.Date, ParameterDirection.Input).Value = Fecha;
            cmd.Parameters.Add("RUTEMPLEADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutEmpleado;
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = Descripcion;
            cmd.Parameters.Add("RUTPROVEEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutProveedor;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se agregó Pedido");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public void modificar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_MODIFICARPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPEDIDO", OracleDbType.Int64, ParameterDirection.Input).Value = IdPedido;
            cmd.Parameters.Add("FECHA", OracleDbType.Date, ParameterDirection.Input).Value = Fecha;
            cmd.Parameters.Add("RUTEMPLEADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutEmpleado;
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = Descripcion;
            cmd.Parameters.Add("RUTPROVEEDOR", OracleDbType.Varchar2, ParameterDirection.Input).Value = RutProveedor;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se modificó Pedido");
            conexion.desconectar(); // se desconecta a la base de datos
        }

        public void eliminar(int numeroPedido)
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_ELIMINARPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID_BORRAR", OracleDbType.Int64, ParameterDirection.Input).Value = numeroPedido;


            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se eliminó Pedido");
            conexion.desconectar(); // se desconecta a la base de datos
        }

        public List<Pedido> listar()
        {
            List<Pedido> lista = new List<Pedido>();


            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARPEDIDOS", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;


            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.IdPedido = int.Parse(reader.GetValue(0).ToString());
                pedido.Fecha = reader.GetDateTime(1);
                pedido.RutEmpleado = reader.GetString(2);
                pedido.Descripcion = reader.GetString(3);
                pedido.RutProveedor = reader.GetString(4);

                lista.Add(pedido);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            Console.WriteLine("DAL: Listado pedidos");
            return lista;
           
        }
        public List<int> listarid(string rutEmpleado)
        {
            List<int> lista = new List<int>();
            int id;

            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARIDPEDIDOS", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            OracleParameter input = cmd.Parameters.Add("RUTEMP", OracleDbType.Varchar2);
            input.Direction = ParameterDirection.Input;
            input.Value = rutEmpleado;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                
               id  = int.Parse(reader.GetValue(0).ToString());

                lista.Add(id);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            Console.WriteLine("DAL: Listado id pedidos");
            return lista;

        }
    }
}
