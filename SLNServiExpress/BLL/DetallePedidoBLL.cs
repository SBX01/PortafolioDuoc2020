using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetallePedidoBLL
    {
        public DetallePedidoBLL()
        {

        }



        public DetallePedidoBLL(DetallePedido nuevo)
        {
            nuevo.CANTIDAD = this.Cantidad;
            nuevo.ESTADO = this.Estado.ToString();
            nuevo.ID_PRODUCTO = this.IdProducto;
            nuevo.RUT_EMPL = this.RutEmpleado;
            nuevo.ID_PEDIDO = this.IdPedido;
            nuevo.COMENTARIO = this.Comentario;
        }

        #region Variables y Propiedades

        int cantidad;
        int idProducto;
        string rutEmpleado;
        int idPedido;
        string comentario;

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public EstadoPedido Estado { get; set; }
        public int IdProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
            }
        }
        public string RutEmpleado
        {
            get
            {
                return rutEmpleado;
            }
            set
            {
                rutEmpleado = value;
            }
        }
        public int IdPedido
        {
            get
            {
                return idPedido;
            }
            set
            {
                idPedido = value;
            }
        }
        public string Comentario
        {
            get
            {
                return comentario;
            }
            set
            {
                comentario = value;
            }
        }

        #endregion

    }

    public enum EstadoPedido
    {
        Pendiente, Aceptada, Facturada, Despachada, Rechazada
    }
}
