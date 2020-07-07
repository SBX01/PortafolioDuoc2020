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
using BLL;
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistrarBoleta.xaml
    /// </summary>
    public partial class RegistrarBoleta : MetroWindow
    {
        DetalleBoletaBLL detalleActual = new DetalleBoletaBLL();
        List<DetalleBoletaBLL> ListaDetalleBoleta = new List<DetalleBoletaBLL>();
        BoletaBLL boletaActual = new BoletaBLL();
        bool agregarDetalle = false;
        int idBoleta = 0;
        int idServicio = 0;
        int indice;

        public RegistrarBoleta()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            var Tpago = (Tipopago[])Enum.GetValues(typeof(Tipopago));
            cmbopago.ItemsSource = Tpago;
            cmbopago.SelectedIndex = 0;

            fechaboleta.Text = DateTime.Now.ToString();
        }

        

        private async void dgDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Carga El detalle de la boleta
            try
            {

               
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }

        private async void btneditbole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }

        private async void btnagregarbolet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                boletaActual.Fechaboleta = DateTime.Now;
                boletaActual.TotalBoleta = int.Parse(txttotalbol.Text);

                boletaActual.Agregar();
                //dgDetalleboleta.ItemsSource = new BoletaBLL().listar(); // funcionalidad no lista
                await this.ShowMessageAsync("Informacion", "La Boleta ha sido creada! \n ahora puede agregar detalle a su boleta", style: MessageDialogStyle.Affirmative);

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }


        private async void Btnlistarproduc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgBoleta.ItemsSource = null;
                dgBoleta.ItemsSource = new BoletaBLL().listar();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos la funcionalidad no esta disponible", style: MessageDialogStyle.Affirmative);
            }

        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloFinanzas ventana = new ModuloFinanzas();
            this.Close();
            ventana.Show();
        }

        private void Btnelimproduc_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }
    }
}
