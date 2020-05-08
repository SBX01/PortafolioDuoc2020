using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        Conexion conexion = new Conexion();

        public string Rut { get; set; }

        public string Nombre { get; set; }

        public string apellidos { get; set; }

        public string correo { get; set; }


        public int telefono { get; set; }


        public string direccion { get; set; }

        public int idusuario { get; set; }


        public Cliente cliente = new Cliente();


        public ClienteBLL()
        {

        }

        public ClienteBLL(Cliente nuevo)
        {
            this.Rut = nuevo.rutCliente;
            this.Nombre = nuevo.nombre;
            this.apellidos = nuevo.apellidos;
            this.correo = nuevo.correo;
            this.direccion = nuevo.direccion;
            this.telefono = nuevo.telefono;
            this.idusuario = nuevo.idUsuario;


        }

        public void Agregar()
        {
            Cliente nuevo = new Cliente();
            nuevo.rutCliente = this.Rut;
            nuevo.nombre = this.Nombre;
            nuevo.apellidos = this.apellidos;
            nuevo.correo = this.correo;
            nuevo.direccion = this.direccion;
            nuevo.telefono = this.telefono;
            nuevo.idUsuario = this.idusuario;
            nuevo.AgregarCliente();
            Console.WriteLine("BLL: agregar");


        }

        public void Modificar()
        {
            Cliente editar = new Cliente();
            editar.rutCliente = this.Rut;
            editar.nombre = this.Nombre;
            editar.apellidos = this.apellidos;
            editar.correo = this.correo;
            editar.direccion = this.direccion;
            editar.telefono = this.telefono;
            editar.idUsuario = this.idusuario;
            editar.EditarCliente();
            Console.WriteLine("BLL: modificar");


        }


        public ClienteBLL buscarPorRut(string rutcli)
        {
            Cliente aBuscar = new Cliente();
            aBuscar = aBuscar.BuscarCliente(rutcli);
            if (aBuscar != null)
            {
                ClienteBLL encontrado = new ClienteBLL();
                encontrado.Rut = aBuscar.rutCliente;
                encontrado.Nombre = aBuscar.nombre;
                encontrado.apellidos = aBuscar.apellidos;
                encontrado.correo = aBuscar.correo;
                encontrado.direccion = aBuscar.direccion;
                encontrado.telefono = aBuscar.telefono;
                encontrado.idusuario = aBuscar.idUsuario;

                return encontrado;
            }

            else
            {

                return null;
            }


        }

        public string buscarRut(string rutCli)
        {
            //cambiar
            Cliente cliente = new Cliente();
            string cliRut;
            cliRut = cliente.BuscarRut(rutCli);
            return cliRut;
        }

        public List<string> listaRutCliente()
        {
            Cliente cliente = new Cliente();
            List<string> lista = cliente.ListarRut();
            return lista;

        }

        public List<ClienteBLL> listartodos()
        {
            Cliente cliente = new Cliente();
            List<Cliente> lista = cliente.listar();
            List<ClienteBLL> listaRetorno = new List<ClienteBLL>();
            foreach (var item in lista)
            {
                listaRetorno.Add(new ClienteBLL(item));

            }
            return listaRetorno;
        }

    }
}
