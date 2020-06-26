using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producto
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;

        #region Propiedades
        long id_producto;
        int precio_Compra;
        int stock_produc;
        int stockCritico;
        string descripcion;
        int precioVenta;
        int id_tipo;
        DateTime fechaVencimiento;

        public long Id_producto 
        {
            get
            {
                return id_producto;
            }
            set
            {
                id_producto = value;
            }

        }
        public int Precio_Compra
        {
            get
            {
                return precio_Compra;
            }
            set
            {
                precio_Compra = value;
            }

        }
        public int Stock_produc
        {
            get
            {
                return stock_produc;
            }
            set
            {
                stock_produc = value;
            }

        }
        public int StockCritico
        {
            get
            {
                return stockCritico;
            }
            set
            {
                stockCritico = value;
            }

        }
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }

        }
        public int PrecioVenta
        {
            get
            {
                return precioVenta;
            }
            set
            {
                precioVenta = value;
            }

        }
        public int Id_tipo
        {
            get
            {
                return id_tipo;
            }
            set
            {
                id_tipo = value;
            }

        }
        public DateTime FechaVencimiento
        {
            get
            {
                return fechaVencimiento;
            }
            set
            {
                fechaVencimiento = value;
            }

        }

        #endregion

        public Producto()
        {
            conexion.Conectar();
            conexion.desconectar();
        }

        public void AgregarProducto()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_AGREGARPRODUCTO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = Id_producto;
            cmd.Parameters.Add("PRECIOCOMPRA", OracleDbType.Int32, ParameterDirection.Input).Value = Precio_Compra;
            cmd.Parameters.Add("STOCK", OracleDbType.Int32, ParameterDirection.Input).Value = Stock_produc;
            cmd.Parameters.Add("STOCKCRITICO", OracleDbType.Int32, ParameterDirection.Input).Value = StockCritico;
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = Descripcion;
            cmd.Parameters.Add("PRECIOVENTA", OracleDbType.Int32, ParameterDirection.Input).Value = PrecioVenta;
            cmd.Parameters.Add("TIPOPRODUCTO", OracleDbType.Int32, ParameterDirection.Input).Value = Id_tipo;
            cmd.Parameters.Add("FECHAVENCIMIENTO", OracleDbType.Date, ParameterDirection.Input).Value = FechaVencimiento;

            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: Se agregó producto");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public void EliminarProducto( long id)
        {
            
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_ELIMINARPRODUCTO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = id;
            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: Se elimino producto");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public void ModificarProducto()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("SP_MODIFICARPRODUCTO", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDPRODUCTO", OracleDbType.Int64, ParameterDirection.Input).Value = Id_producto;
            cmd.Parameters.Add("PRECIOCOMPRA", OracleDbType.Int32, ParameterDirection.Input).Value = Precio_Compra;
            cmd.Parameters.Add("STOCK", OracleDbType.Int32, ParameterDirection.Input).Value = Stock_produc;
            cmd.Parameters.Add("STOCKCRITICO", OracleDbType.Int32, ParameterDirection.Input).Value = StockCritico;
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, ParameterDirection.Input).Value = Descripcion;
            cmd.Parameters.Add("PRECIOVENTA", OracleDbType.Int32, ParameterDirection.Input).Value = PrecioVenta;
            cmd.Parameters.Add("TIPOPRODUCTO", OracleDbType.Int32, ParameterDirection.Input).Value = Id_tipo;
            cmd.Parameters.Add("FECHAVENCIMIENTO", OracleDbType.Date, ParameterDirection.Input).Value = FechaVencimiento;

            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: Se modifico producto");
            conexion.desconectar(); // se desconecta a la base de datos
        }
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();


            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARPRODUCTOS", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;


            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.Id_producto = long.Parse(reader.GetValue(0).ToString());
                producto.Precio_Compra = int.Parse(reader.GetValue(1).ToString());
                producto.Stock_produc = int.Parse(reader.GetValue(2).ToString());
                producto.StockCritico = int.Parse(reader.GetValue(3).ToString());
                producto.Descripcion = reader.GetString(4);
                producto.PrecioVenta = int.Parse(reader.GetValue(5).ToString());
                producto.Id_tipo = int.Parse(reader.GetValue(6).ToString());
                if(string.IsNullOrEmpty(reader.GetValue(7).ToString()))
                {

                }
                else
                {
                    producto.FechaVencimiento = DateTime.Parse(reader.GetValue(7).ToString());
                }
               

               

                lista.Add(producto);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            Console.WriteLine("DAL: Listado Productos");
            return lista;
        }

        public List<Producto> listarSegunProveedor(string rut)
        {
            List<Producto> listaRetorno = new List<Producto>();
            conexion.Conectar();

            string query = " select pr.id_producto,pr.precio_compra,pr.stock_produc,pr.stockcritico_produc,pr.descripcion_produc,pr.precioventa_produc,pr.idtipo,pr.fechavenci_produc " +
                            "from producto pr, proveedor pv , detallecompra dc " +
                            "where pr.id_producto = dc.id_producto and pv.rut_proveedor = dc.rut_proveedor and pv.rut_proveedor = " + rut + " ";
            cmd = new OracleCommand(query, conexion.con);
            cmd.CommandType = CommandType.Text;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.Id_producto = long.Parse(reader.GetValue(0).ToString());
                producto.Precio_Compra = int.Parse(reader.GetValue(1).ToString());
                producto.Stock_produc = int.Parse(reader.GetValue(2).ToString());
                producto.StockCritico = int.Parse(reader.GetValue(3).ToString());
                producto.Descripcion = reader.GetString(4);
                producto.PrecioVenta = int.Parse(reader.GetValue(5).ToString());
                producto.Id_tipo = int.Parse(reader.GetValue(6).ToString());
                if (string.IsNullOrEmpty(reader.GetValue(7).ToString()))
                {

                }
                else
                {
                    producto.FechaVencimiento = DateTime.Parse(reader.GetValue(7).ToString());
                }
            }
            conexion.desconectar();
            return listaRetorno;
        }
    }
}
