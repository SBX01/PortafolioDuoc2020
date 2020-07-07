using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para ModuloRegistros.xaml
    /// </summary>
    public partial class ModuloRegistros : MetroWindow
    {
        public ModuloRegistros()
        {
            InitializeComponent();
            if (!Data.EstaLogeado)
            {
                salir();
            }
        }

        private async void BtnRegistrarClientes_Click(object sender, RoutedEventArgs e)
        {
            //si un empleado con cargo cajero quiere agregar cliente
            if (Data.CargoEmpleadoLogeado.Equals("Cajero") | Data.EsAdmin)
            {
                RegistroClientes registro = new RegistroClientes();
                this.Close();
                registro.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);

            }



        }

        private async void BtnRegistroAuto_Click(object sender, RoutedEventArgs e)
        {
            // si un mecánico quiere agregar un vehiculo a su cliente
            if (Data.CargoEmpleadoLogeado.Equals("Mecanico") | Data.EsAdmin)
            {
                await this.ShowMessageAsync("Lo sentimos", "En mantenimiento.", style: MessageDialogStyle.Affirmative);

                //RegistroAutomovil reg = new RegistroAutomovil();
                //this.Close();
                //reg.Show();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);

            }


        }

        private async void BtnRegistroEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (Data.EsAdmin)
            {
                RegistroEmpleado emp = new RegistroEmpleado();
                this.Close();
                emp.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);
            }
           
        }

        private async void BtnRegistroServicio_Click(object sender, RoutedEventArgs e)
        {
            if (Data.EsAdmin)
            {
                await this.ShowMessageAsync("Lo sentimos", "Funcionalidad en mantenimiento.", style: MessageDialogStyle.Affirmative);
                //RegistroServicio serv = new RegistroServicio();
                //this.Close();
                //serv.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);
            }

        }

        private async void BtnRegistroProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (Data.CargoEmpleadoLogeado.Equals("Bodeguero") | Data.EsAdmin)
            {
                RegistroProveedor prov = new RegistroProveedor();
                this.Close();
                prov.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);

            }

        }

        private async void BtnRegistroProductos_Click(object sender, RoutedEventArgs e)
        {

            if (Data.CargoEmpleadoLogeado.Equals("Bodeguero") | Data.CargoEmpleadoLogeado.Equals("Atencion") | Data.EsAdmin)
            {
                await this.ShowMessageAsync("Lo sentimos", "En mantenimiento.", style: MessageDialogStyle.Affirmative);
                //RegistroProducto prod = new RegistroProducto();
                //this.Close();
                //prod.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usted no dispone de los permisos necesarios para acceder.", style: MessageDialogStyle.Affirmative);

            }
        }

        private void btncerrar_Click(object sender, RoutedEventArgs e)
        {
            salir();

        }

        private async void salir()
        {
            await this.ShowMessageAsync("Iniciar Sesion", "Ingrese a su cuenta", style: MessageDialogStyle.Affirmative);
            Data.EstaLogeado = false;
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            SaludoUsuario main = new SaludoUsuario();
            this.Close();
            main.Show();
        }
    }
}
