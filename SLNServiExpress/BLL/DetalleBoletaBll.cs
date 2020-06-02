using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DetalleBoletaBLL
    {

        public DetalleBoletaBLL()
        {

        }

        public DetalleBoletaBLL(DetalleBoleta nuevo)
        {

            this.Cantidad_Servicio = nuevo.CANTIDAD_SERVICIO;
            this.Id_Boleta = nuevo.ID_BOLETA;
            this.Id_Servicio = nuevo.ID_SERVICIO;
            this.Valor = nuevo.VALOR;



        }

        int cantidad_servicio;
        int id_boleta;
        int id_servicio;
        int valor;
        public int Cantidad_Servicio
        {
            get
            {
                return cantidad_servicio;
            }

            set
            {
                cantidad_servicio = value;
            }

        }



        public int Id_Boleta
        {
            get
            {
                return id_boleta;
            }

            set
            {
                id_boleta = value;
            }
        }

        public int Id_Servicio
        {

            get
            {

                return id_servicio;
            }

            set
            {
                id_servicio = value;
            }

        }


        public int Valor
        {

            get { return valor; }
            set { valor = value; }

        }


        public void agregar()
        {
            DetalleBoleta nuevo = new DetalleBoleta();
            nuevo.CANTIDAD_SERVICIO = this.Cantidad_Servicio;
            nuevo.ID_BOLETA = this.Id_Boleta;
            nuevo.ID_SERVICIO = this.Id_Servicio;
            nuevo.VALOR = this.Valor;

            nuevo.agregar();
            Console.WriteLine("BLL: Agregar Detalle Boleta");

        }

        public void modificar()
        {

            DetalleBoleta editar = new DetalleBoleta();
            editar.CANTIDAD_SERVICIO = this.Cantidad_Servicio;
            editar.ID_BOLETA = this.Id_Boleta;
            editar.ID_SERVICIO = this.Id_Servicio;
            editar.VALOR = this.Valor;

            editar.modificar();
            Console.WriteLine("BLL: Modificar detalle de boleta");

        }

        public void eliminar(int idBolEliminar, int idSerEliminar)
        {
            DetalleBoleta eliminar = new DetalleBoleta();
            eliminar.eliminar(idBolEliminar, idSerEliminar);
            Console.WriteLine("BLL:Eliminar Detalle de Boleta");

        }

        public List<DetalleBoletaBLL> listar()
        {
            List<DetalleBoletaBLL> listarRetorno = new List<DetalleBoletaBLL>();
            List<DetalleBoleta> lista = new DetalleBoleta().listartodo();
            foreach (var detalle in lista)
            {
                listarRetorno.Add(new DetalleBoletaBLL(detalle));
            }
            return listarRetorno;

        }







    }
}
