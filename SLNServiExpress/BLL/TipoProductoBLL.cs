using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoProductoBLL
    {
        TipoProducto tipo = new TipoProducto();
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoProductoBLL()
        {

        }
        public TipoProductoBLL(TipoProducto nuevo)
        {
            this.Id = nuevo.ProductoId;
            this.Descripcion = nuevo.Nombre ;
        }

        public List<TipoProductoBLL> listar()
        {
            List<TipoProductoBLL> listaRetorno = new List<TipoProductoBLL>();
            List<TipoProducto> listaTipos = tipo.listar();
            foreach (var tipo in listaTipos)
            {
                listaRetorno.Add(new TipoProductoBLL(tipo));
            }
            return listaRetorno;
        }

    }
}
