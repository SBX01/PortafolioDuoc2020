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
    /// Lógica de interacción para ListarProveedor.xaml
    /// </summary>
    public partial class ListarProveedor : MetroWindow
    {
        ProveedorBLL prov = new ProveedorBLL();
        public ListarProveedor()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedor reg = new RegistroProveedor();
            this.Close();
            reg.ShowDialog();
        }

        private void dtgproveedor_Loaded(object sender, RoutedEventArgs e)
        {
            var rubros = (Rubros[])Enum.GetValues(typeof(Rubros));
            cmbrubroprov.ItemsSource = rubros;
            cmbrubroprov.SelectedIndex = 1;

            dtgproveedor.ItemsSource = prov.listarTodos();
            dtgproveedor.IsReadOnly = true;
        }

        private void btnbuscarrub_Click(object sender, RoutedEventArgs e)
        {

            List<ProveedorBLL> lista = prov.listarTodos();
            lista = (from pro in lista
                     where pro.Rubro == (Rubros)cmbrubroprov.SelectedItem
                     select pro).ToList();
            dtgproveedor.ItemsSource = null;
            dtgproveedor.ItemsSource = lista;
            dtgproveedor.IsReadOnly = true;


        }

        private void btnlistarprov_Click(object sender, RoutedEventArgs e)
        {
            dtgproveedor.ItemsSource = null;
            dtgproveedor.ItemsSource = prov.listarTodos();
            dtgproveedor.IsReadOnly = true;
        }
    }
}
