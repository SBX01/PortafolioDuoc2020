using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Boleta
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;


        public int IdBoleta { get; set; }

        public DateTime Fechaboleta { get; set; }

        public int TotalBoleta { get; set; }

        public String TipoPago { get; set; }

        public Boleta()
        {

        }

        public void agregar()
        {

            conexion.Conectar();
            cmd = new OracleCommand("SP_AGREGARBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("FECHABOLETA", OracleDbType.Date, ParameterDirection.Input).Value = Fechaboleta;
            cmd.Parameters.Add("TOTALBOLETA", OracleDbType.Int64, ParameterDirection.Input).Value = TotalBoleta;
            cmd.Parameters.Add("TIPOPAGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = TipoPago;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL : se agrego la Boleta");
            conexion.desconectar();

        }


        public void modificar()
        {
            conexion.Conectar();
            cmd = new OracleCommand("SP_MODIFICARBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("IDBOLETA", OracleDbType.Int64, ParameterDirection.Input).Value = IdBoleta;
            cmd.Parameters.Add("FECHABOLETA", OracleDbType.Date, ParameterDirection.Input).Value = Fechaboleta;
            cmd.Parameters.Add("TOTALBOLETA", OracleDbType.Int64, ParameterDirection.Input).Value = TotalBoleta;
            cmd.Parameters.Add("TIPOPAGO", OracleDbType.Varchar2, ParameterDirection.Input).Value = TipoPago; ;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: se modifico Boleta");
            conexion.desconectar();




        }

        public void eliminar(int numeroBoleta)
        {
            conexion.Conectar();
            cmd = new OracleCommand("SP_ELIMINARBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID_BORRARBOLETA", OracleDbType.Int64);


            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: se elimino Boleta");
            conexion.desconectar();
        }

        public List<Boleta> listar()
        {
            List<Boleta> lista = new List<Boleta>();

            conexion.Conectar();
            cmd = new OracleCommand("FN_LISTARBOLETAS");
            cmd.CommandType = CommandType.StoredProcedure;


            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {

                Boleta boleta = new Boleta();
                boleta.IdBoleta = int.Parse(reader.GetValue(0).ToString());
                boleta.Fechaboleta = reader.GetDateTime(1);
                boleta.TotalBoleta = int.Parse(reader.GetValue(2).ToString());
                boleta.TipoPago = reader.GetString(3);

                lista.Add(boleta);


            }
            conexion.desconectar();
            Console.WriteLine("DAL :Listado  Boletas ");
            return lista;
        }

    }
}