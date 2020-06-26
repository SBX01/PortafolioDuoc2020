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
    /// Lógica de interacción para Informes.xaml
    /// </summary>
    public partial class Informes : Window
    {
        const string link = "https://app.powerbi.com/view?r=eyJrIjoiM2E5OTZiM2ItYmVkOC00NTZiLWI2OWUtZDZlYzQ0MTY2YmY3IiwidCI6IjNmZGVmMDc1LWFkODktNGU2OS05ZmU5LTc0MTcyZWNkYmJmNiJ9";
        public Informes()
        {
            InitializeComponent();
            informeWeb.Navigate(link);
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloFinanzas md = new ModuloFinanzas();
            this.Close();
            md.Show();
        }
    }
}
