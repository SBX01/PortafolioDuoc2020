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
    /// Lógica de interacción para EliminarProveedor.xaml
    /// </summary>
    public partial class EliminarProveedor : MetroWindow
    {
        ProveedorBLL proveedor = new ProveedorBLL();
        public EliminarProveedor()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroProveedor reg = new RegistroProveedor();
            this.Close();
            reg.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgProv.ItemsSource = proveedor.listarTodos();
            dgProv.IsReadOnly = true;

            List<ProveedorBLL> lista = proveedor.listarTodos();
            List<string> resultado = new List<string>();
            resultado = (from pr in lista
                         select pr.Rut).ToList();
            cborutprov.ItemsSource = resultado;

           
        }

        private void cborutprov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string buscado = cborutprov.SelectedItem.ToString();
            List<ProveedorBLL> lista = proveedor.listarTodos();
            lista = (from pr in lista
                     where pr.Rut.Equals(buscado)
                     select pr).ToList();

            dgProv.ItemsSource = lista;
            dgProv.IsReadOnly = true;
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            refreshData();
        }

        private async void dgProv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                proveedor = (ProveedorBLL)dgProv.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere Eliminar Datos de Proveedor: " + proveedor.Nombre + " " + proveedor.Apellido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        proveedor.Eliminar(proveedor.Rut);
                        await this.ShowMessageAsync("Informacion", "Eliminados");
                        refreshData();
                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Informacion", "Ha ocurrido un error. \n " +ex.Message);
            }
        }

        void refreshData()
        {
            dgProv.ItemsSource = null;
            dgProv.ItemsSource = proveedor.listarTodos();
            dgProv.IsReadOnly = true;

            List<ProveedorBLL> lista = proveedor.listarTodos();
            List<string> resultado = new List<string>();
            resultado = (from pr in lista
                         select pr.Rut).ToList();
            cborutprov.ItemsSource = resultado;
        }
    }
}
