using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaBLL
    {
        Factura fa = new Factura();
        public DateTime FECHA_FACTURA { get; set; }
        public int NETO { get; set; }
        public int IVA { get; set; }
        public int TOTAL { get; set; }
        public string TIPO_PAGO { get; set; }


        public FacturaBLL()
        {

        }
        public FacturaBLL(Factura emp)
        {
            this.FECHA_FACTURA = fa.FECHA_FACTURA;
            this.NETO = fa.NETO;
            this.IVA = fa.IVA;
            this.TOTAL = fa.TOTAL;

            switch (fa.TIPO_PAGO)
            {
                case "efectivo":
                    this.TIPO_PAGO = "Efectivo";
                    break;
                case "tarjeta":
                    this.TIPO_PAGO = "Tarjeta";
                    break;

            }

        }

        public void Agregar()
        {

            Factura nuevo = new Factura();
            nuevo.FECHA_FACTURA = this.FECHA_FACTURA;
            nuevo.IVA = this.IVA;
            nuevo.NETO = this.NETO;
            nuevo.TOTAL = this.TOTAL;
            nuevo.TIPO_PAGO = this.TIPO_PAGO.ToString();

            nuevo.AgregarFactura();
            Console.WriteLine("BLL: agregar");
        }

        public void Modificar()
        {
            Factura nuevo = new Factura();
            nuevo.FECHA_FACTURA = this.FECHA_FACTURA;
            nuevo.IVA = this.IVA;
            nuevo.NETO = this.NETO;
            nuevo.TOTAL = this.TOTAL;
            nuevo.TIPO_PAGO = this.TIPO_PAGO.ToString();
            nuevo.EditarFac();
            Console.WriteLine("BLL: modificar");


        }


        public List<FacturaBLL> listarTodos()
        {
            Factura emp = new Factura();
            List<Factura> lista = emp.listar();
            List<FacturaBLL> listaRetorno = new List<FacturaBLL>();
            foreach (var item2 in lista)
            {
                listaRetorno.Add(new FacturaBLL(item2));
            }
            return listaRetorno;
        }
    }

    public enum pago { efectivo, tarjeta }

}