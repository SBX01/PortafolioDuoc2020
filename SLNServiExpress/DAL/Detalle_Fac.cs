using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DAL
{
    public class Detalle_fac
    {
        public Conexion conexion = new Conexion();

        OracleCommand cmd = null;

        public int cantidadserv { get; set; }
        public int id_factura { get; set; }
        public int id_servicio { get; set; }
        public int valor { get; set; }



        public void AgregarFactura()
        {
            conexion.Conectar();
            cmd = new OracleCommand("AGREGAFACTURADET", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("cantidadserv", OracleDbType.Varchar2, ParameterDirection.Input).Value = cantidadserv;
            cmd.Parameters.Add("id_factura", OracleDbType.Int32, ParameterDirection.Input).Value = id_factura;
            cmd.Parameters.Add("id_servicio", OracleDbType.Int32, ParameterDirection.Input).Value = id_servicio;
            cmd.Parameters.Add(" valor ", OracleDbType.Int32, ParameterDirection.Input).Value = valor;

            cmd.ExecuteNonQuery();
            conexion.desconectar();
            Console.WriteLine("DAL: se agrego cliente ");



        }


    }


}
