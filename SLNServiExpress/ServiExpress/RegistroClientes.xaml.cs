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
using MahApps.Metro.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;
using BLL;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : MetroWindow
    {
        ClienteBLL cli = new ClienteBLL();
        public RegistroClientes()
        {
            InitializeComponent();
            lbMensaje.Visibility = Visibility.Hidden;
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros modulo = new ModuloRegistros();
            this.Close();
            modulo.ShowDialog();
        }

        private async void Btneditcli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number;
                cli.Rut = txtrutcl.Text;
                cli.Nombre = txtnombrescl.Text;
                cli.apellidos = txtapellidoscl.Text;
                cli.direccion = txtdirecl.Text;
                cli.correo = txtcorreocl.Text;

                if (int.TryParse(txttelefonocl.Text, out number))
                {
                    cli.telefono = number;
                }
                else
                {
                    throw new Exception("numero no corresponde ");
                }
                cli.Modificar();
                await this.ShowMessageAsync("informacion", "Agregado");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("INFORMACION", "Ha ocurrido un error");
                Console.WriteLine("error :" + ex.Message);

            }
        }

        private void Btnelimcli_Click(object sender, RoutedEventArgs e)
        {
            EliminarCliente elim = new EliminarCliente();
            this.Close();
            elim.ShowDialog();
        }

        private void Btnlistar_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes list = new ListarClientes();
            this.Close();
            list.ShowDialog();
        }

        private async void btnagregarcli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL useCli = new UsuarioBLL();
                useCli.nombreUsuario = txtusercl.Text;
                string pass = txtContra.Password;
                var rolCli = Rol.cli;
                useCli.Agregar(useCli.nombreUsuario,pass, rolCli);
                Console.WriteLine("Usuario agregado");
                int id = useCli.getIdUsuario(useCli.nombreUsuario);

                int number;
                cli.Rut = txtrutcl.Text;
                cli.Nombre = txtnombrescl.Text;
                cli.apellidos = txtapellidoscl.Text;
                cli.direccion = txtdirecl.Text;
                cli.correo = txtcorreocl.Text;

                if (int.TryParse(txttelefonocl.Text, out number))
                {
                    cli.telefono = number;
                }
                else
                {
                    throw new Exception("numero no corresponde ");
                }
                cli.idusuario = id;
                cli.Agregar();
                await this.ShowMessageAsync("informacion", "Agregado");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("INFORMACION", "Ha ocurrido un error");
                Console.WriteLine("error :" + ex.Message);

            }

            Limpiar();
        }

        private void Limpiar()
        {
            txtConfirmarPass.Password = string.Empty;
            txtcorreocl.Text = string.Empty;
            txtContra.Password = string.Empty; 
            txtcorreocl.Text = string.Empty;
            txtdirecl.Text = string.Empty;
            txtnombrescl.Text = string.Empty;
            txtrutcl.Text = string.Empty;
            txttelefonocl.Text = string.Empty;
            txtusercl.Text = string.Empty;
            
        }

        private void txtConfirmarPass_KeyUp(object sender, KeyEventArgs e)
        {
            string pass = txtContra.Password;
            try
            {
                if(pass.Equals(txtConfirmarPass.Password))
                {
                    lbMensaje.Visibility = Visibility.Hidden;
                    btnagregarcli.IsEnabled = true;
                }
                else
                {
                    lbMensaje.Visibility = Visibility.Visible;
                    btnagregarcli.IsEnabled = false;
                }
                
            }
            catch (Exception)
            {
                lbMensaje.Visibility = Visibility.Visible;
                btnagregarcli.IsEnabled = false;
            }
          
        }

        private async void dgcliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ClienteBLL cliente = new ClienteBLL();
                cliente = (ClienteBLL)dgcliente.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar Datos de cliente: " + cliente.Nombre + " " + cliente.apellidos + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:


                        txtrutcl.Text = cliente.Rut;
                        txtnombrescl.Text = cliente.Nombre;
                        txtapellidoscl.Text = cliente.apellidos;
                        txtcorreocl.Text = cliente.correo;
                        txtdirecl.Text = cliente.direccion;
                        txttelefonocl.Text = cliente.telefono.ToString();
                        //txtus.Text = cliente.idusuario.ToString();
                        await this.ShowMessageAsync("Informacion", "Datos Cargados.");

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
            }
            catch (Exception error)
            {

                Console.WriteLine("error: " + error.Message);
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgcliente.ItemsSource = cli.listartodos();
            dgcliente.IsReadOnly = true;
        }
    }
}
