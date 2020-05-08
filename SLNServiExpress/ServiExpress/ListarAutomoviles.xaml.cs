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
    /// Lógica de interacción para ListarAutomoviles.xaml
    /// </summary>
    public partial class ListarAutomoviles : MetroWindow
    {
        public ListarAutomoviles()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroAutomovil reg = new RegistroAutomovil();
            this.Close();
            reg.ShowDialog();
        }
    }
}
