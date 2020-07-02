using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleCompra
    {
        public Conexion con = Conexion.Instance;
        OracleCommand cmd = null;
        public int Precio { get; set; }
        public string IdProducto { get; set; }

        public string RutProveedor { get; set; }

        public DetalleCompra()
        {

        }

        public List<DetalleCompra> listar()
        {
            List<DetalleCompra> listaRetorno = new List<DetalleCompra>();
            con.Conectar();

            string query = "select * FROM tipoproducto";
            cmd = new OracleCommand(query, con.con);
            cmd.CommandType = CommandType.Text;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DetalleCompra tp = new DetalleCompra();
                tp.Precio = int.Parse(reader.GetValue(0).ToString());
                tp.IdProducto = reader.GetValue(1).ToString();
                tp.RutProveedor = reader.GetValue(2).ToString();
                listaRetorno.Add(tp);
            }
            con.desconectar();
            return listaRetorno;
        }

        
    }
}
