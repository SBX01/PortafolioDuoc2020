using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Detalle_FacBLL
    {
        Detalle_fac d = new Detalle_fac();

        public int cantidadserv { get; set; }
        public int id_factura { get; set; }
        public int id_servicio { get; set; }
        public int valor { get; set; }


        public Detalle_FacBLL(Detalle_fac emp)
        {
            this.cantidadserv = d.cantidadserv;
            this.id_factura = d.id_factura;
            this.id_servicio = d.id_servicio;
            this.valor = d.valor;



        }

    }

}
