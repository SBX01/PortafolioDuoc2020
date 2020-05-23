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

        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            this.Close();
            log.ShowDialog();
        }

        private void Btncerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            this.Close();
            log.ShowDialog();
        }

        private void btnhacerpedido_Click(object sender, RoutedEventArgs e)
        {
            RegistroPedido ped = new RegistroPedido();
            this.Close();
            ped.Show();
        }
    }
}
