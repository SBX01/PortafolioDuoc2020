using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DAL
{
    public class DetallePedido
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;

        public DetallePedido()
        {

        }

        public int  CANTIDAD { get; set; }
        public string ESTADO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string RUT_EMPL { get; set; }
        public int ID_PEDIDO { get; set; }
        public string COMENTARIO { get; set; }

        public void agregar()
        {

        }
        public void modificar()
        {

        }
        public void eliminar()
        {

        }
        public void listarTodo()
        {

        }

    }
}
