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
using BLL;
using MahApps.Metro.Controls.Dialogs;
using System.Security.Cryptography;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroProveedor.xaml
    /// </summary>
    public partial class RegistroProveedor : MetroWindow
    {
        ProveedorBLL prov = new ProveedorBLL();
        public bool agregoProduc = false;
        public RegistroProveedor()
        {
            InitializeComponent();
          
        }

        private async void Btneditprov_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number;
                prov.Rut = txtrutprov.Text;
                prov.Nombre = txtnombreprov.Text;
                prov.Apellido = txtapellidosprov.Text;
                prov.Correo = txtCorreo.Text;
                if (int.TryParse(txttelefonprov.Text, out number))
                {
                    prov.Tel = number;
                }
                else
                {
                    throw new Exception("El numero de telefono no corresponde");
                }

                prov.Rubro = (Rubros)cmbrubro.SelectedIndex;
                switch (await this.ShowMessageAsync("Informacion", "¿Está seguro de los cambios?", style: MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        prov.Modificar();
                        Cargar();
                        txtrutprov.IsEnabled = true;
                        Limpiar();

                        await this.ShowMessageAsync("Informacion", "El Proveedor ha sido modificado.", style: MessageDialogStyle.Affirmative);

                        break;
                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Acción cancelada.", style: MessageDialogStyle.Affirmative);
                        break;
                }


            }
            catch (Exception ex)
            {
                desplegarMensaje(ex,ex.Message);
            }
        }

        private void Btnelimprov_Click(object sender, RoutedEventArgs e)
        {
            EliminarProveedor eli = new EliminarProveedor();
            this.Close();
            eli.ShowDialog();
        }

        private void Btnlistarprov_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros mod = new ModuloRegistros();
            this.Close();
            mod.ShowDialog();
        }

        private async void btnagregarprov_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                int number;
                ProveedorBLL nuevo = new ProveedorBLL();
                nuevo.Rut = txtrutprov.Text;
                nuevo.Nombre = txtnombreprov.Text;
                nuevo.Apellido = txtapellidosprov.Text;
                nuevo.Correo = txtCorreo.Text;
                if (int.TryParse(txttelefonprov.Text, out number))
                {
                    nuevo.Tel = number;
                }
                else
                {
                    throw new Exception("El numero de telefono no corresponde");
                }

                nuevo.Rubro = (Rubros)cmbrubro.SelectedItem;
                nuevo.Agregar();
                Cargar();
                Limpiar();
                await this.ShowMessageAsync("Informacion", "El Proveedor ha sido registrado.", style: MessageDialogStyle.Affirmative);
            }
            catch (Exception ex)
            {

                desplegarMensaje(ex ,ex.Message);
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cargar();


        }

        private void btncerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void txtrutprov_KeyUp(object sender, KeyEventArgs e)
        {
            // TextBoxHelper.SetWatermark(txtrutprov, "New Value");
            
            try
            {
                List<string> listado = new List<string>();
                string rutPro = txtrutprov.Text;
                rutPro = prov.buscarRut(rutPro); 
                if (!string.IsNullOrEmpty(txtrutprov.Text))
                {
                    listado = prov.listaRutProveedor();
                }
                else
                {
                  
                }

            }
            catch(Exception error)
            {
                desplegarMensaje(error, "ha ocurrido un error, verifique los datos") ;
            }

        }
        void Cargar()
        {
            //se cargan el comboBox con los datos de enum Rubros de proveedorBLL
            var rubros = (Rubros[])Enum.GetValues(typeof(Rubros));
            cmbrubro.ItemsSource = rubros;
            cmbrubro.SelectedIndex = 0;
            //cargar datos de provedores en la dataGrid
            dgProveedor.ItemsSource = prov.listarTodos();
            dgProveedor.IsReadOnly = true;
        }

        private void Limpiar()
        {
            txtrutprov.Text = string.Empty;
            txtnombreprov.Text = string.Empty;
            txtapellidosprov.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txttelefonprov.Text = string.Empty;
        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void dgProveedor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProveedorBLL proveedor = new ProveedorBLL();
                proveedor = (ProveedorBLL)dgProveedor.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar Datos de Proveedor: " + proveedor.Nombre +" "+ proveedor.Apellido +" ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        txtrutprov.IsEnabled = false;
                        txtrutprov.Text = proveedor.Rut;
                        txtnombreprov.Text = proveedor.Nombre;
                        txtapellidosprov.Text = proveedor.Apellido;
                        txtCorreo.Text = proveedor.Correo;
                        txttelefonprov.Text = proveedor.Tel.ToString();
                        cmbrubro.SelectedItem = proveedor.Rubro;
                        await this.ShowMessageAsync("Informacion", "Datos Cargados.");

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
            }
            catch (Exception error)
            {

               Console.WriteLine("error: "+error.Message);
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            dgProveedor.ItemsSource = null;
        }

        async void desplegarMensaje(Exception ex,string mensaje )
        {
            await this.ShowMessageAsync("Informacion", mensaje);
            Console.WriteLine("error: " + ex.Message);
        }
    }
}
