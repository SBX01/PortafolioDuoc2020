using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DAL
{
    public class DetallePedido
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;

        public DetallePedido()
        {

        }

        public int  CANTIDAD { get; set; }
        public string ESTADO { get; set; }
        public long ID_PRODUCTO { get; set; }
        public string RUT_EMPL { get; set; }
        public int ID_PEDIDO { get; set; }
        public string COMENTARIO { get; set; }

        public void agregar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_AGREGARDETALLEPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = this.ID_PRODUCTO;
            cmd.Parameters.Add("IDPEDIDO", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_PEDIDO;
            cmd.Parameters.Add("RUTEMP", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.RUT_EMPL;
            cmd.Parameters.Add("CANTIDADUNIDADES", OracleDbType.Int32, ParameterDirection.Input).Value = this.CANTIDAD;
            cmd.Parameters.Add("ESTADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.ESTADO;
            cmd.Parameters.Add("COMENTARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.COMENTARIO;


            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se agregó Pedido");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public void modificar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_EDITARDETALLEPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = this.ID_PRODUCTO;
            cmd.Parameters.Add("IDPEDIDO", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_PEDIDO;
            cmd.Parameters.Add("RUTEMP", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.RUT_EMPL;
            cmd.Parameters.Add("CANTIDADUNIDADES", OracleDbType.Int32, ParameterDirection.Input).Value = this.CANTIDAD;
            cmd.Parameters.Add("ESTADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.ESTADO;
            cmd.Parameters.Add("COMENTARIO", OracleDbType.Varchar2, ParameterDirection.Input).Value = this.COMENTARIO;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se modificó Pedido");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public void eliminar(string rutEmpEliminar, long idProdEliminar, int idPedidoEliminar)
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_ELIMINARDETALLEPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPEDIDO", OracleDbType.Int32, ParameterDirection.Input).Value = idPedidoEliminar;
            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = idProdEliminar;
            cmd.Parameters.Add("RUTEMP", OracleDbType.Varchar2, ParameterDirection.Input).Value = rutEmpEliminar;


            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se eliminó Pedido");
            conexion.desconectar();
        }
        public List<DetallePedido> listarTodo()
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARDETALLEPEDIDO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;


            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                DetallePedido detalle = new DetallePedido();
                detalle.CANTIDAD = int.Parse(reader.GetValue(0).ToString());
                detalle.ESTADO = reader.GetString(1);
                detalle.ID_PRODUCTO = long.Parse(reader.GetValue(2).ToString());
                detalle.RUT_EMPL = reader.GetString(3);
                detalle.COMENTARIO = reader.GetString(4);
                detalle.ID_PEDIDO = int.Parse(reader.GetValue(5).ToString());

                lista.Add(detalle);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            Console.WriteLine("DAL: Listado pedidos");

            return lista;
        }

    }
}
