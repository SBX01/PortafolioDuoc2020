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
using MahApps.Metro.Controls;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para EliminarServicio.xaml
    /// </summary>
    public partial class EliminarServicio : MetroWindow
    {
        public EliminarServicio()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroServicio reg = new RegistroServicio();
            this.Close();
            reg.ShowDialog();
        }
    }
}
