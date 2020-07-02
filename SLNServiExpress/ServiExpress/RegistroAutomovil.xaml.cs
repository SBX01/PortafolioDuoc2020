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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroAutomovil.xaml
    /// </summary>
    public partial class RegistroAutomovil : MetroWindow
    {
        public RegistroAutomovil()
        {
            InitializeComponent();
            if (!Data.EstaLogeado)
            {
                salir();
            }
        }


        private void Btnelimauto_Click(object sender, RoutedEventArgs e)
        {
            EliminarAutomovil el = new EliminarAutomovil();
            this.Close();
            el.ShowDialog();
        }

        private void Btnlistaraut_Click(object sender, RoutedEventArgs e)
        {
            ListarAutomoviles list = new ListarAutomoviles();
            this.Close();
            list.ShowDialog();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloRegistros mod = new ModuloRegistros();
            this.Close();
            mod.ShowDialog();
        }

        private async void salir()
        {
            await this.ShowMessageAsync("Iniciar Sesion", "Ingrese a su cuenta", style: MessageDialogStyle.Affirmative);
            Data.EstaLogeado = false;
            MainWindow main = MainWindow.Instance;
            this.Close();
            main.ShowDialog();
        }

        private void btneditaut_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
