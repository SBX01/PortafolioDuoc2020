using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
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

            return lista;
        }

    }
}
