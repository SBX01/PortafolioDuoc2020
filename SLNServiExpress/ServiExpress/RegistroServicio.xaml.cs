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
    /// Lógica de interacción para RegistroServicio.xaml
    /// </summary>
    public partial class RegistroServicio : MetroWindow
    {
        public RegistroServicio()
        {
            InitializeComponent();
        }

        private void Btnelimser_Click(object sender, RoutedEventArgs e)
        {
            EliminarServicio eli = new EliminarServicio();
            this.Close();
            eli.ShowDialog();
        }

        private void Btneditser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnlistarser_Click(object sender, RoutedEventArgs e)
        {
            ListarServicio list = new ListarServicio();
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
