using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /*.
        999 primeros 3 digitos del rut del proveedor.
        999 los 3 siguientes familia de producto 
        99999999 los 8 siguientes corresponde a la fecha de vencimiento.
        999 los 3 ultimos corresponden al tipo de producto especifico
        
    */
    public class ProductoBLL
    {
        #region Propiedades
        long id_producto;
        int precio_Compra;
        int stock_produc;
        int stockCritico;
        string descripcion;
        int precioVenta;
        int id_tipo;
        DateTime fechaVencimiento;


        public long Id_producto { get => id_producto; set => id_producto = value; }
        public int Precio_Compra { get => precio_Compra; set => precio_Compra = value; }
        public int Stock_produc { get => stock_produc; set => stock_produc = value; }
        public int StockCritico { get => stockCritico; set => stockCritico = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }

        #endregion
        public ProductoBLL() { }

        public ProductoBLL(Producto nuevo)
        {
            this.Id_producto = nuevo.Id_producto;
            this.Precio_Compra = nuevo.Precio_Compra;
            this.Stock_produc = nuevo.Stock_produc;
            this.StockCritico = nuevo.StockCritico;
            this.Descripcion = nuevo.Descripcion;
            this.PrecioVenta = nuevo.PrecioVenta;
            this.Id_tipo = nuevo.Id_tipo;
            this.FechaVencimiento = nuevo.FechaVencimiento;
        }

        public void Agregar()
        {
            Producto nuevo = new Producto();
            nuevo.Id_producto = this.Id_producto;
            nuevo.Precio_Compra = this.Precio_Compra;
            nuevo.Stock_produc = this.Stock_produc;
            nuevo.StockCritico = this.StockCritico;
            nuevo.Descripcion = this.Descripcion;
            nuevo.PrecioVenta = this.PrecioVenta;
            nuevo.Id_tipo = this.Id_tipo;
            nuevo.FechaVencimiento = this.FechaVencimiento;
            nuevo.AgregarProducto();
            Console.WriteLine("BLL: agregar");
        }

        public void Modificar()
        {
            Producto editar = new Producto();
            editar.Id_producto = this.Id_producto;
            editar.Precio_Compra = this.Precio_Compra;
            editar.Stock_produc = this.Stock_produc;
            editar.StockCritico = this.StockCritico;
            editar.Descripcion = this.Descripcion;
            editar.PrecioVenta = this.PrecioVenta;
            editar.Id_tipo = this.Id_tipo;
            editar.FechaVencimiento = this.FechaVencimiento;
            editar.ModificarProducto();
            Console.WriteLine("BLL: Modificar");
        }

        public void Eliminar()
        {

        }

        public List<ProductoBLL> ListarTodo()
        {
            List<ProductoBLL> listaRetorno = new List<ProductoBLL>();


            return listaRetorno;
        }


        long Crearid_producto(string rutProveedor, int familiaProd, DateTime fechaVen, int tipoProd)
        {
            string famProd = familiaProd.ToString();
            string vencimiento = fechaVen.ToShortDateString();
            string tipo = tipoProd.ToString();
            string idPro;
            string fecha = vencimiento.Replace("/", "");
            fecha = vencimiento.Replace("-", "");
            idPro = rutProveedor.Substring(0, 3) + famProd.Substring(0, 3) + fecha + tipo.Substring(0, 3);
            return long.Parse(idPro);
        }
    }
}
