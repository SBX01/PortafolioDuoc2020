using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Validaciones;

namespace BLL
{
    public class BoletaBLL
    {
        Boleta boleta = new Boleta();
        private int _total;

        public int IdBoleta { get; set; }


        public DateTime Fechaboleta { get; set; }

        public int TotalBoleta 
        {
            get
            {
                return _total;
            }
            set
            {
                if(value > 0)
                {
                    _total = value;
                }
                else
                {
                    throw new Exception("El valor no puede ser negativo");
                }
            }
        }

        public Tipopago TipoPago { get; set; }

        public BoletaBLL()
        {

        }

        public BoletaBLL(Boleta nuevo)
        {
            this.IdBoleta = nuevo.IdBoleta;
            this.Fechaboleta = nuevo.Fechaboleta;
            if (Enum.IsDefined(typeof(Tipopago), nuevo.TipoPago))
            {
                this.TipoPago = (Tipopago)Enum.Parse(typeof(Tipopago), nuevo.TipoPago);
            }
            this.TotalBoleta = nuevo.TotalBoleta;


        }
        public void Agregar()
        {
            Boleta nuevo = new Boleta();
            nuevo.IdBoleta = this.IdBoleta;
            nuevo.Fechaboleta = this.Fechaboleta;
            nuevo.TipoPago = this.TipoPago.ToString();
            nuevo.TotalBoleta = this.TotalBoleta;

            nuevo.agregar();
            Console.WriteLine("BLL : Agregar boleta");

        }

        public void Modificar()
        {
            Boleta editar = new Boleta();
            editar.IdBoleta = this.IdBoleta;
            editar.Fechaboleta = this.Fechaboleta;
            editar.TipoPago = this.TipoPago.ToString();
            editar.TotalBoleta = this.TotalBoleta;

            editar.modificar();
            Console.WriteLine("BLL : Editar pedido");

        }

        public void Eliminar(int nroBoleta)
        {

            List<Boleta> lista = boleta.listar();
            var result = (from b in lista
                          where b.IdBoleta.Equals(nroBoleta)
                          select b).FirstOrDefault();
            result.eliminar(nroBoleta);
            Console.WriteLine("BLL : Eliminar boleta");



        }

        public List<BoletaBLL> listar()
        {
            List<BoletaBLL> listaRetorno = new List<BoletaBLL>();
            List<Boleta> lista = boleta.listar();
            foreach (var boleta in lista)
            {
                listaRetorno.Add(new BoletaBLL(boleta));

            }

            return listaRetorno;

        }



    }
    public enum Tipopago
    {
        Efectivo, Tarjeta

    }
}