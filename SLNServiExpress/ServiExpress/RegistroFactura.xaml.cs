using BLL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroFactura.xaml
    /// </summary>
    public partial class RegistroFactura : MetroWindow
    {

        FacturaBLL f = new FacturaBLL();
        public RegistroFactura()
        {
            InitializeComponent();
            cmboreserv0.Visibility = Visibility.Hidden;
        }


        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloFinanzas ventana = new ModuloFinanzas();
            this.Close();
            ventana.Show();
        }

        private void cmbopago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btneditbole_Click(object sender, RoutedEventArgs e)
        {
            // Editar 
            try
            {

                f.FECHA_FACTURA = fechafac.SelectedDate.GetValueOrDefault();
                f.IVA = int.Parse(txtiva.Text);
                f.NETO = int.Parse(txtneto.Text);
                f.TOTAL = int.Parse(txttotal.Text);
                //f.TIPO_PAGO = cmbopago.SelectedValue.ToString();
                f.TIPO_PAGO = cmbopago.Text;

                f.Modificar();
                await this.ShowMessageAsync("informacion", "Factura Modificado");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("INFORMACION", "Ha ocurrido un error");
                Console.WriteLine("error :" + ex.Message);

            }
        }

        private async void btnagregarproduc_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                f.FECHA_FACTURA = fechafac.SelectedDate.GetValueOrDefault();
                f.IVA = int.Parse(txtiva.Text);
                f.NETO = int.Parse(txtneto.Text);
                f.TOTAL = int.Parse(txttotal.Text);
                //f.TIPO_PAGO = cmbopago.SelectedValue.ToString();
                f.TIPO_PAGO = cmbopago.Text;

                f.Agregar();

                await this.ShowMessageAsync("Informacion", "Agregado");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("INFORMACION", "Ha ocurrido un error");
                Console.WriteLine("error :" + ex.Message);

            }
        }

        private void Btnelimproduc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnlistarproduc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // carga de comboBox tipo de pago
            var estados = (pago[])Enum.GetValues(typeof(pago));
            cmbopago.ItemsSource = estados;
        }

        private void txtneto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double neto = int.Parse(txtneto.Text);
                double iva = Math.Round(neto * 0.19);
                double total = neto + iva;
                txtiva.Text = iva.ToString();
                txttotal.Text = total.ToString();
            }
            catch (Exception ex)
            {

              
            }
        }
    }
}