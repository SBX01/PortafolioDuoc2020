using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs; // se le agregan los dialogos
using BLL;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using System.Data;


namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        UsuarioBLL user = new UsuarioBLL();

        //LoginService.LoginServiceClient login = new LoginService.LoginServiceClient(); // se crea la instancia 


        public MainWindow()
        {
            InitializeComponent();

            Data.NombreUser = string.Empty;
            Data.EsAdmin = false;
            Data.EstaLogeado = false;
            Data.IdUserActivo = 0;
            Data.RolUserActivo = string.Empty;
            Data.CargoEmpleadoLogeado = string.Empty;
        }


        private void Btnregistro_Click(object sender, RoutedEventArgs e)
        {
            Data.EstaLogeado = false;
            RegistroEmpleado    registrar = new RegistroEmpleado();
            this.Close();
            registrar.Show();

        }

        private async void Btningresar_Click(object sender, RoutedEventArgs e) // el async es para los mensajes de dialogo de mahapss
        {

 
            string username = txtusuario.Text;
            string password = pbcontra.Password;
            /*
            try
            {   // Se guardan las variables de nombre de usuario y la pass


                if (login.login(username, password))//se llama la funcion "login(u,p)" del web service y se le ingresan los parametros
                {
                    //si son correctos se retorna el rol del usuario
                    string result = login.getRol(username); // se llama la funcion getrol(u) del web service y se le asigna el mismo parametro
                    
                    switch (result) //segun el resultado guardado se hara lo siguiente
                    {
                        case "cli": // si es cliente desplegará un mensaje de que no puede ingresar aca con el mensaje de  mahapps
                            await this.ShowMessageAsync("Lo sentimos!", "usted no tiene permiso para acceder.", style: MessageDialogStyle.Affirmative);
                            Limpiar();
                            break;
                        case "no esta": // en el caso que el rol este mal escrito entrará a este punto
                            await this.ShowMessageAsync("Lo sentimos!", "Su cuenta presenta un error.", style: MessageDialogStyle.Affirmative);
                            Limpiar();
                            break;

                        case "error": // si hay un error pasa aca, el error viene desde el web service
                            await this.ShowMessageAsync("Lo sentimos!", "Su cuenta presenta un error.", style: MessageDialogStyle.Affirmative);
                            Limpiar();
                            break;
                        default: // si es "emp"(empleado) o "adm"(administrador) entrará aca donde abre la ventana
                            IniciarVentana(username, result);
                            break;

                    }

                }
                else // si los datos no estan en la base de datos desplegará este error
                {
                    
                    await this.ShowMessageAsync("Usuario incorrecto", "verifique que su usuario o clave sean los correctos.", style: MessageDialogStyle.Affirmative);
                }
            }
            catch (Exception ex) // si hay problemas de coneccion con la web service entra aca
            {
            */
             //   Console.WriteLine("No conectado en webService" + ex.Message);
                // intenta conectarse desde la base de datos
                if (user.TryLogin(username, password))
                {
                    
                    string result = user.GetRolUsuario(username); ;
                    switch (result) 
                    {
                        case "cli": 
                            await this.ShowMessageAsync("Lo sentimos!", "usted no tiene permiso para acceder.", style: MessageDialogStyle.Affirmative);
                            Limpiar();
                            break;

                        case "Error":
                            await this.ShowMessageAsync("Lo sentimos!", "Su cuenta presenta un error.", style: MessageDialogStyle.Affirmative);
                            Limpiar();
                            break;
                        default:
                            IniciarVentana(username, result);
                            break;

                    }
                }
                else
                {
                    
                    await this.ShowMessageAsync("Lo sentimos!", "El usuario ingresado no existe.", style: MessageDialogStyle.Affirmative);
                }

           // }
            Limpiar();
        }

        private void IniciarVentana(string username, string result)
        {
            if (result.Equals("adm"))
            {
                List<EmpleadoBLL> listaEmp = new EmpleadoBLL().listarTodos();
                Data.EsAdmin = true;
               
                Data.RolUserActivo = result;
                List<UsuarioBLL> listaUs = new UsuarioBLL().DatosUsuario();
                var idUsuario = (from us in listaUs
                                 where us.nombreUsuario == username
                                 select us.idUsuario).FirstOrDefault();
                Data.IdUserActivo = idUsuario;
                var rutEmp = (from emp in listaEmp
                              where emp.ID_USUARIO == Data.IdUserActivo
                              select emp.RUT_EMPL).FirstOrDefault();
                var nombre = (from emp in listaEmp
                              where emp.ID_USUARIO == Data.IdUserActivo
                              select emp.nombreCompleto).FirstOrDefault();
                Data.NombreUser = nombre;
                Data.RutEmpleadoActivo = rutEmp;
            }
            else
            {
                List<EmpleadoBLL> listaEmp = new EmpleadoBLL().listarTodos();
                List<UsuarioBLL> listaUs = new UsuarioBLL().DatosUsuario();
                var idUsuario = (from us in listaUs
                                 where us.nombreUsuario == username
                                 select us.idUsuario).FirstOrDefault();
                Data.IdUserActivo = idUsuario;
                Console.WriteLine("Id User: " + idUsuario);

                var nombre = (from emp in listaEmp
                              where emp.ID_USUARIO == Data.IdUserActivo
                              select emp.nombreCompleto).FirstOrDefault();

                var rutEmp = (from emp in listaEmp
                              where emp.ID_USUARIO == Data.IdUserActivo
                              select emp.RUT_EMPL).FirstOrDefault();
                Data.RutEmpleadoActivo = rutEmp;
                Console.WriteLine("Nombre: " + nombre);
                Data.NombreUser = nombre;
                Data.EsAdmin = false;
                Data.RolUserActivo = result;
            }
            Data.EstaLogeado = true;

            Console.WriteLine("Nombre: " + Data.NombreUser);
            SaludoUsuario saludo = new SaludoUsuario();
            this.Close();
            saludo.Show();
        }

        private void Limpiar()
        {
            txtusuario.Clear();
            pbcontra.Clear();
        }
    }
}
