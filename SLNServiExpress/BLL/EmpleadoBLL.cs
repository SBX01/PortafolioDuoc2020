using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadoBLL
    {
        Empleado emp = new Empleado();
        public string RUT_EMPL { get; set; }
        public string NOMBRE_EMPL { get; set; }
        public string APELLIDO_EMPL { get; set; }
        public string DIRECCION_EMPL { get; set; }
        public int TELEFONO_EMPL { get; set; }
        public string CORREO_EMP { get; set; }
        public Cargos CARGO_EMPL { get; set; }
        public int ID_USUARIO { get; set; }

        public string nombreCompleto
        {
            get
            {
                return NOMBRE_EMPL + " " + APELLIDO_EMPL;
            }
            set
            {
                value = NOMBRE_EMPL + " " + APELLIDO_EMPL;
            }   
        }

        public EmpleadoBLL()
        {

        }
        public EmpleadoBLL(Empleado emp)
        {
            this.ID_USUARIO = emp.ID_USUARIO;
            this.RUT_EMPL = emp.RUT_EMPL;
            this.NOMBRE_EMPL = emp.NOMBRE_EMPL;
            this.APELLIDO_EMPL = emp.APELLIDO_EMPL;
            this.DIRECCION_EMPL = emp.DIRECCION_EMPL;
            this.TELEFONO_EMPL = emp.TELEFONO_EMPL;
            this.CORREO_EMP = emp.CORREO_EMP;
            switch (emp.CARGO_EMPL)
            {
                case "Cajero":
                    this.CARGO_EMPL = Cargos.Cajero;
                    break;
                case "Mecanico":
                    this.CARGO_EMPL = Cargos.Cajero;
                    break;
                case "Bodeguero":
                    this.CARGO_EMPL = Cargos.Cajero;
                    break;
                case "Atencion":
                    this.CARGO_EMPL = Cargos.Cajero;
                    break;
            }
           
        }

        public void Agregar()
        {

            Empleado nuevo = new Empleado();
            nuevo.ID_USUARIO = this.ID_USUARIO;
            nuevo.RUT_EMPL = this.RUT_EMPL;
            nuevo.NOMBRE_EMPL = this.NOMBRE_EMPL;
            nuevo.APELLIDO_EMPL = this.APELLIDO_EMPL;
            nuevo.DIRECCION_EMPL = this.DIRECCION_EMPL;
            nuevo.TELEFONO_EMPL = this.TELEFONO_EMPL;
            nuevo.CORREO_EMP = this.CORREO_EMP;
            nuevo.CARGO_EMPL = this.CARGO_EMPL.ToString();

            nuevo.AgregarEmpleado();
            Console.WriteLine("BLL: agregar");
        }

        public List<EmpleadoBLL> listarTodos()
        {
            Empleado emp = new Empleado();
            List<Empleado> lista = emp.listadoempleados();
            List<EmpleadoBLL> listaRetorno = new List<EmpleadoBLL>();
            foreach (var item in lista)
            {
                listaRetorno.Add(new EmpleadoBLL(item));
            }
            return listaRetorno;
        }
    }

    public enum Cargos { Cajero, Mecanico, Bodeguero, Atencion, Soporte }
}
