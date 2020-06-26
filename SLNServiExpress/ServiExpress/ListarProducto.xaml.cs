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
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para ListarProducto.xaml
    /// </summary>
    public partial class ListarProducto : MetroWindow
    {
        public bool DesdeProv { get; set; }
        public ListarProducto()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            volver(DesdeProv);
        }

        void volver(bool desdeProvedoor)
        {
            if (desdeProvedoor)
            {
                this.Close();
            }
            else
            {
                RegistroProducto reg = new RegistroProducto();
                this.Close();
                reg.ShowDialog();
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {



            cmbprovd.ItemsSource = new ProveedorBLL().listarTodos();
            cmbprovd.DisplayMemberPath = "nombreCompleto";
            cmbprovd.SelectedValuePath = "Rut";
            cmbprovd.SelectedIndex = 0;

  
            cmbfamilem.ItemsSource = new TipoProductoBLL().listar();
            cmbfamilem.DisplayMemberPath = "Descripcion";
            cmbfamilem.SelectedValuePath = "Id";
            cmbfamilem.SelectedIndex = 0;

            dtgempleado.ItemsSource = new ProductoBLL().ListarTodo();
            dtgempleado.IsReadOnly = true;

        }

        private async void dtgempleado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductoBLL elegido = (ProductoBLL)dtgempleado.SelectedItem;
                await this.ShowMessageAsync("Informacion", "Ha seleccionado " + elegido.Descripcion + ".");
                Data.IdProductoSeleccionado = elegido.Id_producto;
            }
            catch (Exception)
            {

            }

        }

        private void cmbprovd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dtgempleado.ItemsSource = null;
                string buscar = (String)cmbprovd.SelectedValue;

                dtgempleado.ItemsSource = new ProductoBLL().ListarSegunProv(buscar);
            }
            catch (Exception)
            {

                
            }

        }

        private void cmbfamilem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dtgempleado.ItemsSource = null;
                int buscar = (int)cmbfamilem.SelectedValue;
                var listaProductos = new ProductoBLL().ListarTodo();
                var listaNueva = (from pd in listaProductos
                                  where pd.Id_tipo == buscar
                                  select pd).ToList();
                dtgempleado.ItemsSource = listaNueva;
            }
            catch (Exception)
            {

               
            }

        }

        private void btnlistarprod_Click(object sender, RoutedEventArgs e)
        {
            dtgempleado.ItemsSource = new ProductoBLL().ListarTodo();
            dtgempleado.IsReadOnly = true;
        }
    }
}
