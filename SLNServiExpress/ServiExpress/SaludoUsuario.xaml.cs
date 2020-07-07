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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Navigation;
using BLL;
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para SaludoUsuario.xaml
    /// </summary>
    public partial class SaludoUsuario : MetroWindow
    {
        public SaludoUsuario()
        {
            InitializeComponent();
            lblbienvenido.Content = "Bienvenido " + Data.NombreUser;
        }

        private void Btnmodulore_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros modulo = new ModuloRegistros();
            this.Close();
            modulo.ShowDialog();
        }

        private void Btninfoedi_Click(object sender, RoutedEventArgs e)
        {
            // ventana editar usuario
            EditarUser edit = new EditarUser();
            edit.ShowDialog();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();

            this.Close();
            log.Show();
            Data.EstaLogeado = false;
        }

        private void Btncerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            this.Close();
            log.Show();
            Data.EstaLogeado = false;
        }

        private async void btnhacerpedido_Click(object sender, RoutedEventArgs e)
        {
            if(Data.CargoEmpleadoLogeado == Cargos.Bodeguero.ToString())
            {
                RegistroPedido ped = new RegistroPedido();
                this.Close();
                ped.Show();
            }
            else
            {
                await this.ShowMessageAsync("Atencion", "No tiene los permisos para acceder.");
            }
           
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgDatos.IsReadOnly = true;

            ListarSegunCargo();
        }

        private void ListarSegunCargo()
        {
            switch (Data.RolUserActivo)
            {
                case "adm":
                    // si es Administrador se listarán los usuarios registrados
                    List<UsuarioBLL> listaUsuarios = new UsuarioBLL().DatosUsuario();
                    var resultadoUser = (from users in listaUsuarios
                                         select new { users.idUsuario, users.nombreUsuario, RolUsuario = users.GetRolUsuario(users.nombreUsuario) }).ToList();
                    dgDatos.ItemsSource = resultadoUser;
                    break;
                case "emp":
                    // si es Un empleado se listarán segun su cargo horas reservadas, o pedidos hechos
                    List<EmpleadoBLL> listaEmpleado = new EmpleadoBLL().listarTodos();
                    var resultadoEmp = (from emp in listaEmpleado
                                        where emp.nombreCompleto == Data.NombreUser
                                        select emp.CARGO_EMPL).FirstOrDefault();

                    switch (resultadoEmp)
                    {
                        case Cargos.Atencion://si es atención se listarán todas las horas reservadas.

                            //list<reservahorabll> listareserva = new reservahorabll().listartodos();
                            //dgDatos.ItemsSource = listareserva;


                            break;
                        case Cargos.Mecanico: // si es mecánico se listarán sus horas agendadas.

                            //List<ServicioBLL> listareservaMecanico = new ServicioBLL().listartodos();
                            //List<EmpleadoBLL> empleados = new EmpleadoBLL().listarTodos();
                            //var reservaMecanico = (from servcio in listareservaMecanico
                            //                       join meca in empleados on servcio.RutEmpleado equals meca.RUT_EMPL
                            //                       where servcio.RutEmpleado == meca.RUT_EMPL
                            //                       select servcio).ToList();


                            //dgDatos.ItemsSource = reservaMecanico;

                            break;

                        case Cargos.Bodeguero: // si es bodeguero  listaran los pedidos.

                            dgDatos.ItemsSource = new PedidoBLL().listar();
                            break;

                        case Cargos.Cajero: //  si es cajero se listarán los productos.
                            dgDatos.ItemsSource = new ProductoBLL().ListarTodo();
                            break;
                    }
                    Data.CargoEmpleadoLogeado = resultadoEmp.ToString();
                    break;
                  
            }

           
        }

        private async void btnmoduadm_Click(object sender, RoutedEventArgs e)
        {
            ModuloFinanzas ventanaFin = new ModuloFinanzas();
            // si el usuario es administrador o cajero puede entrar
            if (Data.EsAdmin || Data.CargoEmpleadoLogeado == Cargos.Cajero.ToString())
            {
               
                this.Close();
                ventanaFin.Show();
            }
            else
            {
                await this.ShowMessageAsync("Atencion", "No tiene los permisos para acceder.");
            }
        }
    }
}
