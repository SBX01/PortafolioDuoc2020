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

        private void BtnRegistrarClientes_Click(object sender, RoutedEventArgs e)
        {
            //preguntar
                RegistroClientes registro = new RegistroClientes();
                this.Close();
                registro.ShowDialog();


        }

        private void BtnRegistroAuto_Click(object sender, RoutedEventArgs e)
        {
            //preguntar
            RegistroAutomovil reg = new RegistroAutomovil();
            this.Close();
            reg.ShowDialog();
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

        private void BtnRegistroServicio_Click(object sender, RoutedEventArgs e)
        {
            //preguntar
            RegistroServicio serv = new RegistroServicio();
            this.Close();
            serv.ShowDialog();
        }

        private void BtnRegistroProveedor_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedor prov = new RegistroProveedor();
            this.Close();
            prov.ShowDialog();
        }

        private void BtnRegistroProductos_Click(object sender, RoutedEventArgs e)
        {
            RegistroProducto prod = new RegistroProducto();
            this.Close();
            prod.ShowDialog();
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

    }
}
