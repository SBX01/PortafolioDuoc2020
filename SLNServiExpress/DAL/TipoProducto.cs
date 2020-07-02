using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoProducto
    {
        public Conexion con = Conexion.Instance;
        OracleCommand cmd = null;
        public int ProductoId { get; set; }
        public string Nombre { get; set; }

        public TipoProducto()
        {

        }

        public List<TipoProducto> listar()
        {
            List<TipoProducto> listaRetorno = new List<TipoProducto>();
            con.Conectar();

            string query = "select * FROM tipoproducto";
            cmd = new OracleCommand(query, con.con);
            cmd.CommandType = CommandType.Text;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TipoProducto tp = new TipoProducto();
                tp.ProductoId = int.Parse(reader.GetValue(0).ToString());
                tp.Nombre = reader.GetValue(1).ToString();
                listaRetorno.Add(tp);
            }
            con.desconectar();
            return listaRetorno;
        }
    }
}
