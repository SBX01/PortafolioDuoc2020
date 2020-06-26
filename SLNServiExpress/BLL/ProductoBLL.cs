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

        public void Eliminar(long id)
        {
            Producto eliminar = new Producto();
            eliminar.EliminarProducto(id);
        }

        public List<ProductoBLL> ListarTodo()
        {
            List<ProductoBLL> listaRetorno = new List<ProductoBLL>();
            List<Producto> lista = new Producto().ListarProductos();

            foreach (var producto in lista)
            {
                listaRetorno.Add(new ProductoBLL(producto));
            }
            return listaRetorno;
        }

        public List<ProductoBLL> ListarSegunProv( string rut)
        {
            List<ProductoBLL> listaRetorno = new List<ProductoBLL>();
            List<Producto> lista = new Producto().listarSegunProveedor(rut);

            foreach (var producto in lista)
            {
                listaRetorno.Add(new ProductoBLL(producto));
            }
            return listaRetorno;
        }


        long Crearid_producto(string rutProveedor, int familiaProd, DateTime? fechaVen, int tipoProd)
        {
            string famProd = familiaProd.ToString();
            string vencimiento = fechaVen.ToString();
            string tipo = tipoProd.ToString();
            string idPro;

            if (famProd.Length == 2)
            {
                famProd = "0" + famProd;
            }
            if (famProd.Length == 1)
            {
                famProd = "00" + famProd;
            }
            if (tipo.Length == 2)
            {
                tipo = "0" + tipo;
            }
            if (tipo.Length == 1)
            {
                tipo = "00" + tipo;
            }
            string fecha = vencimiento.Replace("/", "");
            fecha = fecha.Replace("-", "");
            fecha = fecha.Replace(":", "");

            if (string.IsNullOrEmpty(vencimiento))
            {
                fecha = "00000000";
            }
            else
            {
                fecha = fecha.Substring(0, 8);
            }
            Console.WriteLine(rutProveedor.Substring(0, 3) + famProd.Substring(0, 3) + fecha + tipo.Substring(0, 3));
            idPro = rutProveedor.Substring(0, 3) + famProd.Substring(0, 3) + fecha + tipo.Substring(0, 3);

            return long.Parse(idPro);
        }
    }
}
