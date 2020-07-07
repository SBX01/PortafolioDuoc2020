using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Validaciones;


namespace BLL
{
    public class PedidoBLL
    {
        Pedido Pedido = new Pedido();
        Validacion val = new Validacion();

        DateTime fecha;
        string descripcion;
        string rutEmpleado;
        string rutProveedor;


        public int IdPedido { get; set; }
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                if(value >= DateTime.MinValue)
                {
                    if (value <= DateTime.MaxValue)
                    {
                        fecha = value;
                    }
                    else
                    {
                        throw new Exception("La fechaes mayor a la maxima permitida " + DateTime.MaxValue.ToString());
                    }
                   
                }
                else
                {
                    throw new Exception("La fecha es menor a la mínima permitida " + DateTime.MinValue.ToString());
                }
               
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
                if (!string.IsNullOrEmpty(value))
                {
                    descripcion = value;
                }
                else
                {
                    throw new Exception("La descripcion esta vacia");
                }
               
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
                if (!string.IsNullOrEmpty(value))
                {

                    if (val.validarRut(value))
                    {
                        rutEmpleado = value;
                    }
                    else
                    {
                        throw new Exception("El rut ingresado no es válido");
                    }
                }
                else
                {
                    throw new Exception("El rut se encuentra vacio");
                }
            }
        }
        public string RutProveedor
        {
            get
            {
                return rutProveedor;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {

                    if (val.validarRut(value))
                    {
                        rutProveedor = value;
                    }
                    else
                    {
                        throw new Exception("El rut ingresado no es válido");
                    }
                }
                else
                {
                    throw new Exception("El rut se encuentra vacio");
                }
            }
        }

        public PedidoBLL()
        {

        }
        public PedidoBLL(Pedido nuevo)
        {
            this.IdPedido = nuevo.IdPedido;
            this.Fecha = nuevo.Fecha;
            this.Descripcion = nuevo.Descripcion;
            this.RutEmpleado = nuevo.RutEmpleado;
            this.RutProveedor = nuevo.RutProveedor;

        }

        public void Agregar(List<DetallePedidoBLL> listaDetalle)
        {
            // Datos pedido
            Pedido nuevo = new Pedido();
            nuevo.IdPedido = this.IdPedido;
            nuevo.Fecha = this.Fecha;
            nuevo.Descripcion = this.Descripcion;
            nuevo.RutEmpleado = this.RutEmpleado;
            nuevo.RutProveedor = this.RutProveedor;
            nuevo.agregar();

            // Datos detalle pedido
            foreach (var detalle in listaDetalle)
            {
                detalle.IdPedido = nuevoId();
                detalle.agregar();
            } 
            Console.WriteLine("BLL: Agregar pedido.");
        }
        public void Modificar(List<DetallePedidoBLL> listaDetalle)
        {
            Pedido editar = new Pedido();
            editar.IdPedido = this.IdPedido;
            editar.Fecha = this.Fecha;
            editar.Descripcion = this.Descripcion;
            editar.RutEmpleado = this.RutEmpleado;
            editar.RutProveedor = this.RutProveedor;
            editar.modificar();
            foreach (var detalle in listaDetalle)
            {
                detalle.IdPedido = editar.IdPedido;
                detalle.eliminar(editar.RutEmpleado,detalle.IdProducto,detalle.IdPedido);
                detalle.agregar();
                detalle.modificar();
            }
            Console.WriteLine("BLL: Editar pedido.");
        }
        public void EliminarPedido(int nroPedido)
        {
            
            List<Pedido> lista = Pedido.listar();
            var result = (from p in lista
                          where p.IdPedido.Equals(nroPedido)
                          select p).FirstOrDefault();
            result.eliminar(nroPedido);
            Console.WriteLine("BLL: Eliminar pedido.");
        }


        public List<PedidoBLL> listar()
        {
            List<PedidoBLL> listaRetorno = new List<PedidoBLL>();
            List<Pedido> lista = Pedido.listar();
            foreach (var pedido in lista)
            {
                listaRetorno.Add(new PedidoBLL(pedido));
            }
            return listaRetorno;
        }

        public int nuevoId()
        {
            List<Pedido> lista = Pedido.listar();
            IdPedido = (from pedidonuevo in lista
                        select pedidonuevo.IdPedido).Max();
            return IdPedido;
        }

        public List<int> listarid(string rutEmpleado)
        {
            List<int> listaRetorno = new List<int>();
            listaRetorno = new Pedido().listarid(rutEmpleado);
            return listaRetorno;
        }

    }
}
