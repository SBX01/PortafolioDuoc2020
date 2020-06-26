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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para ModuloFinanzas.xaml
    /// </summary>
    public partial class ModuloFinanzas : MetroWindow
    {
        public ModuloFinanzas()
        {
            InitializeComponent();
        }

        private void btnFactura_Click(object sender, RoutedEventArgs e)
        {
            RegistroFactura factura = new RegistroFactura();
            this.Close();
            factura.Show();
        }

        private void btnBoleta_Click(object sender, RoutedEventArgs e)
        {
            RegistrarBoleta boleta = new RegistrarBoleta();
            this.Close();
            boleta.Show();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            SaludoUsuario main = new SaludoUsuario();
            this.Close();
            main.Show();
        }

        private void btnInforme_Click(object sender, RoutedEventArgs e)
        {
            Informes inf = new Informes();
            this.Close();
            inf.Show();
        }
    }
}
