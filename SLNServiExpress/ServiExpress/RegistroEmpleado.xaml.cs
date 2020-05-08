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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroEmpleado.xaml
    /// </summary>
    public partial class RegistroEmpleado : MetroWindow
    {
        EmpleadoBLL empleado = new EmpleadoBLL();
        public RegistroEmpleado()
        {
            InitializeComponent();
            lbMensajeCorreo.Visibility = Visibility.Hidden;
            lbMensajePass.Visibility = Visibility.Hidden;
        }

        private void Btneditemp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnelimemp_Click(object sender, RoutedEventArgs e)
        {
            EliminarEmpleado eli  = new EliminarEmpleado();
            this.Close();
            eli.ShowDialog();
        }

        private void Btnlistaremp_Click(object sender, RoutedEventArgs e)
        {
            ListarEmpleado list = new ListarEmpleado();
            this.Close();
            list.ShowDialog();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros mod = new ModuloRegistros();
            this.Close();
            mod.ShowDialog();
        }

        private async void btnagregaremp_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                UsuarioBLL useEmp= new UsuarioBLL();
                useEmp.nombreUsuario = txtuserem.Text;
                string pass = txtPass.Password;
                var rolEmp = Rol.emp;
                useEmp.Agregar(useEmp.nombreUsuario, pass, rolEmp);
                Console.WriteLine("Usuario agregado");
                int id = useEmp.getIdUsuario(useEmp.nombreUsuario);

                int number;
                empleado.RUT_EMPL = txtrutem.Text;
                empleado.NOMBRE_EMPL = txtnombem.Text;
                empleado.APELLIDO_EMPL = txtapelem.Text;
                empleado.DIRECCION_EMPL = txtdirem.Text;
                empleado.CORREO_EMP = txtcorem.Text;
                empleado.CARGO_EMPL = (Cargos)cmbcargoem.SelectedItem;

                if (int.TryParse(txtelefem.Text, out number))
                {
                    empleado.TELEFONO_EMPL = number;
                }
                else
                {
                    throw new Exception("numero no corresponde ");
                }
                empleado.ID_USUARIO = id;
                empleado.Agregar();
                await this.ShowMessageAsync("informacion", "Agregado");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("INFORMACION", "Ha ocurrido un error");
                Console.WriteLine("error :" + ex.Message);

            }
        }

        private void Image_GotFocus(object sender, RoutedEventArgs e)
        {
            // buscar con rut

        }

        private void txtconfpasem_KeyUp(object sender, KeyEventArgs e)
        {
            string correo = txtcorem.Text;
            try
            {
                if (correo.Equals(txtconfem.Text))
                {
                    lbMensajeCorreo.Visibility = Visibility.Hidden;
                    btnagregaremp.IsEnabled = true;
                    btnagregaremp.IsEnabled = true;
                }
                else
                {
                    lbMensajeCorreo.Visibility = Visibility.Visible;
                    btnagregaremp.IsEnabled = false;
                    btnagregaremp.IsEnabled = false;
                }

            }
            catch (Exception)
            {
                lbMensajeCorreo.Visibility = Visibility.Visible;
                btnagregaremp.IsEnabled = false;
                btnagregaremp.IsEnabled = false;
            }
        }
        // Controla que el correo sea el mismo
        private void txtconfem_KeyUp(object sender, KeyEventArgs e)
        {
            string correo = txtcorem.Text;
            try
            {
                if (correo.Equals(txtconfem.Text))
                {
                    lbMensajeCorreo.Visibility = Visibility.Hidden;
                    btnagregaremp.IsEnabled = true;
                    btnagregaremp.IsEnabled = true;
                }
                else
                {
                    lbMensajeCorreo.Visibility = Visibility.Visible;
                    btnagregaremp.IsEnabled = false;
                    btnagregaremp.IsEnabled = false;
                }

            }
            catch (Exception)
            {
                lbMensajeCorreo.Visibility = Visibility.Visible;
                btnagregaremp.IsEnabled = false;
                btnagregaremp.IsEnabled = false;
            }
        }

        private void txtPassConfir_KeyUp(object sender, KeyEventArgs e)
        {
            string pass = txtPass.Password;
            try
            {
                if (pass.Equals(txtPassConfir.Password))
                {
                    lbMensajePass.Visibility = Visibility.Hidden;

                }
                else
                {
                    lbMensajePass.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lbMensajePass.Visibility = Visibility.Visible;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // carga el comboBox
            var cargos = (Cargos[])Enum.GetValues(typeof(Cargos));
            cmbcargoem.ItemsSource = cargos;
            cmbcargoem.SelectedIndex = 1;
        }
    }
}
