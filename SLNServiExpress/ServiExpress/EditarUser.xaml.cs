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
    /// Lógica de interacción para EditarUser.xaml
    /// </summary>
    public partial class EditarUser : MetroWindow
    {
        bool contraSegura = false;
        public EditarUser()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Limpiar()
        {
            txtnombre.Text = string.Empty;
            passUser.Password = string.Empty;
            passUserConfirmar.Password = string.Empty;
            lblDetalle.Content = string.Empty;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UsuarioBLL user = new UsuarioBLL();
            try
            {

                string oldPass = passUserOld.Password;
                string userOld = txtnombreOld.Text;
                if (user.TryLogin(userOld, oldPass))
                {
                    switch (await this.ShowMessageAsync("Atencion", "Esta seguro de los cambios", MessageDialogStyle.AffirmativeAndNegative))
                    {
                        case MessageDialogResult.Affirmative:
                            if (contraSegura)
                            {
                                user.modificar(userOld, passUserConfirmar.Password, txtnombre.Text);
                                await this.ShowMessageAsync("Atencion", "Datos guardados.");
                                lblDetalle.Content = "Correcto.";
                                Limpiar();
                            }
                            else
                            {
                                throw new Exception("Contraseña poco segura.");
                            }

                            break;
                        case MessageDialogResult.Negative:
                            await this.ShowMessageAsync("Atencion", "Acción cancelada.");
                            break;
                    }
                }
                else
                {
                    throw new Exception("Usuario inválido");
                }
               
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Atencion", "Error: "+ ex.Message);
            }
        }

        private void passUserConfirmar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (passUser.Password.Equals(passUserConfirmar.Password))
                {
                    contraSegura = true;
                    lblDetalle.Content = "Correcto.";
                    lblDetalle.Foreground = Brushes.Lime;
                }
                else
                {
                    lblDetalle.Content = "Ingrese la misma contraseña.";
                    lblDetalle.Foreground = Brushes.Red;
                    contraSegura = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void passUser_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(passUser.Password.Length < 5)
                {
                    lblDetalle.Content = "Contraseña muy corta.";
                    lblDetalle.Foreground = Brushes.Red;
                }
                else
                {
                    lblDetalle.Content = "Correcto.";
                    lblDetalle.Foreground = Brushes.Lime;
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
