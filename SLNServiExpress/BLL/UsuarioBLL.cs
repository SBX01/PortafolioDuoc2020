using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {

        Usuario usuario = new Usuario();

        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }

        public UsuarioBLL()
        {
           
        }



        public UsuarioBLL(Usuario nuevo)
        {
            this.idUsuario = nuevo.idUsuario;
            this.nombreUsuario = nuevo.nombreUsuario;
        }

        public void Agregar(string nombreUsuario, string password ,Rol rol)
        {
            string rolUsuario = rol.ToString();
            usuario.conexion.Conectar();
            usuario.AgregarUsuario(nombreUsuario, password, rolUsuario);
            usuario.conexion.desconectar();
            Console.WriteLine("BLL: agregar");
        }

        public bool TryLogin(string nombreUsuario, string password)
        {
 
           string result = usuario.TryLogin(nombreUsuario,password);
            if (result.Equals("true"))
            {
                
                return true;
            }
            else
            {

                return false;
            }
        }

        public string GetRolUsuario(string nombreUsuario)
        {
            usuario.conexion.Conectar();
            string result = usuario.rolUsuario(nombreUsuario) ;
            switch (result)
            {
                case "adm":
                    usuario.conexion.desconectar();
                    return result;

                case "emp":
                    usuario.conexion.desconectar();
                    return result;

                case "cli":
                    usuario.conexion.desconectar();
                    return result;

                default:
                    usuario.conexion.desconectar();
                    return "Error";
            }
        }

        public List<UsuarioBLL> DatosUsuario()
        {
            List<Usuario> lista = usuario.listar();
            List<UsuarioBLL> listadoRetorno = new List<UsuarioBLL>();
            foreach (var item in lista)
            {
                listadoRetorno.Add(new UsuarioBLL(item));
            }
            return listadoRetorno;
        }

        public int getIdUsuario(string nombreUser)
        {
            List<Usuario> lista = usuario.listar();

            int idUser = (from user in lista
                          where user.nombreUsuario.Equals(nombreUser)
                          select user.idUsuario).FirstOrDefault();
            return idUser;
        }


    }

    public enum Rol { adm , emp ,cli }
}
