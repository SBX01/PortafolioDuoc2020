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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroProducto.xaml
    /// </summary>
    public partial class RegistroProducto : MetroWindow
    {
        public RegistroProducto()
        {
            InitializeComponent();
        }

        private void Btneditprodu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnelimproduc_Click(object sender, RoutedEventArgs e)
        {
            EliminarProducto el = new EliminarProducto();
            this.Close();
            el.ShowDialog();
        }

        private void Btnlistarproduc_Click(object sender, RoutedEventArgs e)
        {
            ListarProducto list = new ListarProducto();
            this.Close();
            list.ShowDialog();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros mod = new ModuloRegistros();
            this.Close();
            mod.ShowDialog();
        }
    }
}
