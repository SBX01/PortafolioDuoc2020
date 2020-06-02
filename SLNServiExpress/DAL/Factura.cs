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
    public class Factura
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;


        public DateTime FECHA_FACTURA { get; set; }
        public int NETO { get; set; }
        public int IVA { get; set; }
        public int TOTAL { get; set; }
        public string TIPO_PAGO { get; set; }




        public void AgregarFactura()
        {
            conexion.Conectar();
            cmd = new OracleCommand(" AGREGAFACTURA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("fecha_factura", OracleDbType.Date, ParameterDirection.Input).Value = FECHA_FACTURA;
            cmd.Parameters.Add("neto", OracleDbType.Int32, ParameterDirection.Input).Value = NETO;
            cmd.Parameters.Add("iva", OracleDbType.Int32, ParameterDirection.Input).Value = IVA;
            cmd.Parameters.Add("total", OracleDbType.Int32, ParameterDirection.Input).Value = TOTAL;
            cmd.Parameters.Add("tipopago", OracleDbType.Varchar2, ParameterDirection.Input).Value = TIPO_PAGO;
            cmd.ExecuteNonQuery();
            conexion.desconectar();
            Console.WriteLine("DAL: se agrego factura ");



        }

        public Factura BuscarFactura(string idf)
        {
            conexion.Conectar();
            string query = "";

            Factura encontrada = new Factura();
            query = "SELECT * FROM factura WHERE  id_factura  ='{0}'";
            string parametros = string.Format(query, idf);
            cmd = new OracleCommand(parametros, conexion.con);

            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Factura cli = new Factura();
                cli.FECHA_FACTURA = reader.GetDateTime(0);
                cli.IVA = reader.GetInt32(9);
                cli.NETO = reader.GetInt32(9);
                cli.TOTAL = reader.GetInt32(9);
                cli.TIPO_PAGO = reader.GetString(4);


            }
            conexion.desconectar();
            return encontrada;



        }


        public void EditarFac()
        {
            conexion.Conectar();
            cmd = new OracleCommand("EditarFac", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("fecha_factura", OracleDbType.Date, ParameterDirection.Input).Value = FECHA_FACTURA;
            cmd.Parameters.Add("neto", OracleDbType.Int32, ParameterDirection.Input).Value = NETO;
            cmd.Parameters.Add("iva", OracleDbType.Int32, ParameterDirection.Input).Value = IVA;
            cmd.Parameters.Add("total", OracleDbType.Int32, ParameterDirection.Input).Value = TOTAL;
            cmd.Parameters.Add("tipopago", OracleDbType.Varchar2, ParameterDirection.Input).Value = TIPO_PAGO;

            cmd.ExecuteNonQuery();

            Console.WriteLine("DAL: se ha modificado la factura");
            conexion.desconectar();
        }



        public List<Factura> listar()
        {
            conexion.Conectar(); // se conecta a la base de datos
            cmd = new OracleCommand("FN_LISTARFacturas", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Factura> lista = new List<Factura>();

            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                Factura cli = new Factura();
                cli.FECHA_FACTURA = reader.GetDateTime(0);
                cli.IVA = int.Parse(reader.GetValue(9).ToString());
                cli.NETO = int.Parse(reader.GetValue(9).ToString());
                cli.TOTAL = int.Parse(reader.GetValue(9).ToString());
                cli.TIPO_PAGO = reader.GetString(15);


                lista.Add(cli);
            }
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;



        }
    }


}