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
    public class DetalleBoleta
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null;


        public DetalleBoleta()
        {

        }

        public int CANTIDAD_SERVICIO { get; set; }

        public int ID_BOLETA { get; set; }

        public int ID_SERVICIO { get; set; }

        public int VALOR { get; set; }


        public void agregar()
        {

            conexion.Conectar();
            cmd = new OracleCommand("SP_AGREGARDETALLEBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID_BOLETA", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_BOLETA;
            cmd.Parameters.Add("ID_SERVICIO", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_SERVICIO;
            cmd.Parameters.Add("CANTIDAD_SERVICIO", OracleDbType.Int32, ParameterDirection.Input).Value = this.CANTIDAD_SERVICIO;
            cmd.Parameters.Add("VALOR", OracleDbType.Int32, ParameterDirection.Input).Value = this.VALOR;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL:Se agrego Boleta");
            conexion.desconectar();


        }

        public void modificar()
        {

            conexion.Conectar();

            cmd = new OracleCommand("SP_EDITARDETALLEBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID_BOLETA", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_BOLETA;
            cmd.Parameters.Add("ID_SERVICIO", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_SERVICIO;
            cmd.Parameters.Add("CANTIDAD_SERVICIO", OracleDbType.Int32, ParameterDirection.Input).Value = this.CANTIDAD_SERVICIO;
            cmd.Parameters.Add("VALOR", OracleDbType.Int32, ParameterDirection.Input).Value = this.VALOR;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se modifico Boleta");
            conexion.desconectar();
        }

        public void eliminar(int idBolEliminar, int idServEliminar)
        {
            conexion.Conectar();
            cmd = new OracleCommand("SP_ELIMINARDETALLEBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID_BOLETA", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_BOLETA;
            cmd.Parameters.Add("ID_SERVICIO", OracleDbType.Int32, ParameterDirection.Input).Value = this.ID_SERVICIO;

            cmd.ExecuteNonQuery();
            Console.WriteLine("DAL: Se eliminó Boleta");
            conexion.desconectar();



        }

        public List<DetalleBoleta> listartodo()
        {

            List<DetalleBoleta> lista = new List<DetalleBoleta>();
            conexion.Conectar();
            cmd = new OracleCommand("FN_LISTARDETALLEBOLETA", conexion.con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter output = cmd.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
            while (reader.Read())
            {
                DetalleBoleta detalle = new DetalleBoleta();
                detalle.ID_BOLETA = int.Parse(reader.GetValue(0).ToString());
                detalle.ID_SERVICIO = int.Parse(reader.GetValue(1).ToString());
                detalle.CANTIDAD_SERVICIO = int.Parse(reader.GetValue(2).ToString());
                detalle.VALOR = int.Parse(reader.GetValue(3).ToString());

                lista.Add(detalle);
            }
            conexion.desconectar();
            Console.WriteLine("DAL:Listado Boleta");
            return lista;


        }


    }
}