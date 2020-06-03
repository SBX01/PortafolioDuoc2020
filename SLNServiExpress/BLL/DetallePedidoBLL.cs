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
            this.Cantidad = nuevo.CANTIDAD;
            if (Enum.IsDefined(typeof(EstadoPedido), nuevo.ESTADO))
            {
                this.Estado = (EstadoPedido)Enum.Parse(typeof(EstadoPedido), nuevo.ESTADO);
            }
            this.IdProducto = nuevo.ID_PRODUCTO;
            this.RutEmpleado = nuevo.RUT_EMPL;
            this.IdPedido = nuevo.ID_PEDIDO;
            this.Comentario = nuevo.COMENTARIO;
        }

        #region Variables y Propiedades

        int cantidad;
        long idProducto;
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
                if (value < 1)
                {
                    throw new Exception("La cantidad no puede ser menor a 0.");
                }
                else
                {
                    cantidad = value;
                }
               
            }
        }
        public EstadoPedido Estado { get; set; }
        public long IdProducto
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



        public void agregar()
        {
            DetallePedido nuevo = new DetallePedido();
            nuevo.CANTIDAD = this.Cantidad;
            nuevo.ESTADO = this.Estado.ToString();
            nuevo.ID_PRODUCTO = this.IdProducto;
            nuevo.RUT_EMPL = this.RutEmpleado;
            nuevo.ID_PEDIDO = this.IdPedido;
            nuevo.COMENTARIO = this.Comentario;
            nuevo.agregar();
            Console.WriteLine("BLL: Agregar Detalle Pedido");


        }
        public void modificar()
        {

            DetallePedido editar = new DetallePedido();


            editar.CANTIDAD = this.Cantidad;
            editar.ESTADO = this.Estado.ToString();
            editar.ID_PRODUCTO = this.IdProducto;
            editar.RUT_EMPL = this.RutEmpleado;
            editar.ID_PEDIDO = this.IdPedido;
            editar.COMENTARIO = this.Comentario;
            editar.modificar();
            Console.WriteLine("BLL: modificar Detalle Pedido ");
        }
        public void eliminar(string rutEmpEliminar, long idProducEliminar, int idPedidoEliminar)
        {
            DetallePedido eliminar = new DetallePedido();

            eliminar.eliminar(rutEmpEliminar, idProducEliminar, idPedidoEliminar);
        }
        public List<DetallePedidoBLL> listar()
        {
            // lista todos los pedidos
            List<DetallePedidoBLL> listaRetorno = new List<DetallePedidoBLL>();
            List<DetallePedido> lista = new DetallePedido().listarTodo();
            foreach (var detalle in lista)
            {
                listaRetorno.Add(new DetallePedidoBLL(detalle));
            }
            return listaRetorno;

        }


    }

    public enum EstadoPedido
    {
        Pendiente, // nuevo pedido
        Aceptado, // el proveedor acepta
        Despachado, // proveedor envia pedido
        Rechazado,// proveedor rechaza
        Cancelado, // empleado rechaza
        Finalizado // pedido llegó y se chequeó
    }
}
