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
    public class Empleado
    {
        public Conexion conexion = new Conexion();
        OracleCommand cmd = null; 

        public string RUT_EMPL { get; set; }
        public string NOMBRE_EMPL { get; set; }
        public string APELLIDO_EMPL { get; set; }
        public string DIRECCION_EMPL { get; set; }
        public int TELEFONO_EMPL { get; set; }
        public string CORREO_EMP { get; set; }
        public string CARGO_EMPL { get; set; }
        public int ID_USUARIO { get; set; }

        public void AgregarEmpleado()
        {
            try
            {
                conexion.Conectar();
                OracleCommand com = new OracleCommand("AgregarEmpleado", conexion.con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("rut", OracleDbType.Varchar2).Value = this.RUT_EMPL;
                com.Parameters.Add("nombre", OracleDbType.Varchar2).Value = this.NOMBRE_EMPL;
                com.Parameters.Add("apellido", OracleDbType.Varchar2).Value = this.APELLIDO_EMPL;
                com.Parameters.Add("direccion", OracleDbType.Varchar2).Value = this.DIRECCION_EMPL;
                com.Parameters.Add("telefono", OracleDbType.Int32).Value = this.TELEFONO_EMPL;
                com.Parameters.Add("correo", OracleDbType.Varchar2).Value = this.CORREO_EMP;
                com.Parameters.Add("cargo", OracleDbType.Varchar2).Value = this.CARGO_EMPL;
                com.Parameters.Add("id_usuario", OracleDbType.Int32).Value = this.ID_USUARIO;
                com.ExecuteNonQuery();
                conexion.desconectar();
                Console.WriteLine("Exito: " + this.NOMBRE_EMPL +"Empelaod Guardado correctamente");

            }
            catch (Exception error)
            {

                Console.WriteLine("Error: "+error.Message);
            }
        }

        public List<Empleado> listadoempleados()
        {
            List<Empleado> lista = new List<Empleado>();

            conexion.Conectar();
            OracleCommand com = new OracleCommand("FN_LISTAREMPLEADO", conexion.con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            OracleParameter output = com.Parameters.Add("L_CURSOR", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;


            com.ExecuteNonQuery();
            OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

            while (reader.Read())
            {
                Empleado emp = new Empleado();
                emp.RUT_EMPL = reader.GetString(0);
                emp.NOMBRE_EMPL = reader.GetString(1);
                emp.APELLIDO_EMPL = reader.GetString(2);
                emp.DIRECCION_EMPL = reader.GetString(3);
                emp.TELEFONO_EMPL = int.Parse(reader.GetValue(4).ToString());
                emp.CORREO_EMP = reader.GetString(5);
                emp.CARGO_EMPL = reader.GetString(6);
                emp.ID_USUARIO = int.Parse(reader.GetValue(7).ToString());

                lista.Add(emp);
            }
                
            conexion.desconectar(); // se desconecta a la base de datos
            return lista;

 
        }
    }
}
