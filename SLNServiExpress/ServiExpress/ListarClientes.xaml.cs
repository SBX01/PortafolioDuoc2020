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
using BLL;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : MetroWindow
    {
        ClienteBLL cli = new ClienteBLL();
        public ListarClientes()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroClientes registro = new RegistroClientes();
            this.Close();
            registro.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
            dtgclientes.ItemsSource = cli.listartodos();
            dtgclientes.IsReadOnly = true;
        }

        private void btnlistarcl_Click(object sender, RoutedEventArgs e)
        {
            dtgclientes.ItemsSource = null;
            dtgclientes.ItemsSource = cli.listartodos();
            dtgclientes.IsReadOnly = true;
        }

        private void Btnatras_Click_1(object sender, RoutedEventArgs e)
        {
            RegistroClientes registro = new RegistroClientes();
            this.Close();
            registro.ShowDialog();
        }
    }
}
