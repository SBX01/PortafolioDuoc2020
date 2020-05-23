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

        }
        public void EliminarProducto()
        {

        }
        public void ModificarProducto()
        {

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

                producto.FechaVencimiento =DateTime.Parse(reader.GetValue(7).ToString());

               

                lista.Add(producto);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            Console.WriteLine("DAL: Listado Productos");
            return lista;
        }

    }
}
