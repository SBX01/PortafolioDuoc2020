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

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para ListarEmpleado.xaml
    /// </summary>
    public partial class ListarEmpleado : MetroWindow
    {
        public ListarEmpleado()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroEmpleado reg = new RegistroEmpleado();
            this.Close();
            reg.Show();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {//carga grilla
            EmpleadoBLL emp = new EmpleadoBLL();
            dtgempleado.ItemsSource = emp.listarTodos();

            // carga el comboBox
            var cargos = (Cargos[])Enum.GetValues(typeof(Cargos));
            cmbcargoem.ItemsSource = cargos;
            cmbcargoem.SelectedIndex = 1;
        }

        private void btnbuscarcargem_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoBLL emp = new EmpleadoBLL();
            List<EmpleadoBLL> lista = emp.listarTodos();
            lista = (from empleado in lista
                     where empleado.CARGO_EMPL == (Cargos)cmbcargoem.SelectedItem
                     select empleado).ToList();
            dtgempleado.ItemsSource = null;
            dtgempleado.ItemsSource = lista;
            dtgempleado.IsReadOnly = true;
        }

        private void btnlistarem_Click(object sender, RoutedEventArgs e)
        {
            dtgempleado.ItemsSource = null;
            EmpleadoBLL emp = new EmpleadoBLL();
            dtgempleado.ItemsSource = emp.listarTodos();
        }
    }
}
