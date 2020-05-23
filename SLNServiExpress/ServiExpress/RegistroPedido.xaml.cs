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
using System.Windows.Media.Media3D;
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroPedido.xaml
    /// </summary>
    public partial class RegistroPedido : MetroWindow
    {
        DetallePedidoBLL pedidoActual = new DetallePedidoBLL();
        PedidoBLL pedido = new PedidoBLL();
        bool agregarDetalle = false;
        int idPedido;
        public RegistroPedido()
        {
            InitializeComponent();
            dgDetalleProducto.IsReadOnly = true;
        }


        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error: "+ ex.Message);
            }
            

        }

        public void dgproduc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
               
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnEditarDetalle_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnagregarped_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pedido = new PedidoBLL();
                pedido.Fecha = DateTime.Now;
                pedido.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                pedido.Descripcion = tbDescripcion.Text;
                pedido.RutProveedor = cboProveedor.SelectedValue.ToString();
                pedido.Agregar();
                dgDetalleProducto.ItemsSource = new PedidoBLL().listar();
                await this.ShowMessageAsync("Informacion", "El Pedido ha sido creado! \n ahora puede agregar productos a su pedido", style: MessageDialogStyle.Affirmative);

            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " +ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }

        void iniciar(bool existePedido)
        {
            if (existePedido)
            {
                dgDetalleProducto.Visibility = Visibility.Visible;
                GridPedido.Visibility = Visibility.Hidden;

            }
            else
            {
                dgDetalleProducto.Visibility = Visibility.Hidden;
                GridPedido.Visibility = Visibility.Visible;
            }



        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<PedidoBLL> listar = pedido.listar();
                dgDetalleProducto.ItemsSource = listar;
                if (dgDetalleProducto.ItemsSource!= null)
                {
                    iniciar(true);
                }
                else
                {
                    iniciar(false);
                }
            }
            catch (Exception)
            {

                throw;
            }

            cboProveedor.ItemsSource = new ProveedorBLL().listarTodos();
            cboProveedor.DisplayMemberPath = "nombreCompleto";
            cboProveedor.SelectedValuePath = "Rut";
            cboProveedor.SelectedIndex = 0;


            List<EmpleadoBLL> listadoEmpleados = new EmpleadoBLL().listarTodos();
            var listaBodegueros = (from emp in listadoEmpleados
                                   where emp.CARGO_EMPL == Cargos.Bodeguero
                                   select emp).ToList();
            cboEmpleado.ItemsSource = listaBodegueros;
            cboEmpleado.DisplayMemberPath = "nombreCompleto";
            cboEmpleado.SelectedValuePath = "RUT_EMPL";
            cboEmpleado.SelectedIndex = 0;

            cboProductos.ItemsSource = new ProductoBLL().ListarTodo();
            cboProductos.DisplayMemberPath = "Descripcion" ;
            cboProductos.SelectedValuePath = "Id_producto";
            cboProductos.SelectedIndex = 0;

            var estados = (EstadoPedido[])Enum.GetValues(typeof(EstadoPedido));
            cboEstado.ItemsSource = estados;
            cboEstado.SelectedIndex = 0;

        }


        private void checkAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (checkAgregar.IsChecked == true)
            {
                agregarDetalle = false;
                iniciar(agregarDetalle);

            }
            if (checkAgregar.IsChecked == false)
            {
                agregarDetalle = true;
                iniciar(agregarDetalle);
            }

            Console.WriteLine(agregarDetalle);
        }

        private void btncerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            this.Close();
            Data.EstaLogeado = false;
            Data.NombreUser = string.Empty;
            inicio.Show();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            SaludoUsuario main = new SaludoUsuario();
            this.Close();
            main.Show();
        }

        private async void dgDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DetallePedidoBLL detalle = new DetallePedidoBLL();
                detalle = (DetallePedidoBLL)dgDetalleProducto.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar Datos del Pedido N°: " + pedido.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        idPedido = detalle.IdPedido;
                        cboProductos.SelectedItem = detalle.IdProducto;
                        cboEstado.SelectedItem = detalle.Estado;
                        txtCantidadDetalle.Text = detalle.Cantidad.ToString();
                        txtComentarios.Text = detalle.Comentario;
                        await this.ShowMessageAsync("Informacion", "Datos Cargados.");

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);

            }
        }

        private async void dgDetalleProducto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PedidoBLL pedido = new PedidoBLL();
                pedido = (PedidoBLL)dgDetalleProducto.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar Datos del Pedido N°: " + pedido.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        idPedido = pedido.IdPedido;
                        cboEmpleado.SelectedValue = pedido.RutEmpleado;
                        cboProveedor.SelectedValue = pedido.RutProveedor;
                        tbDescripcion.Text = pedido.Descripcion;
                        await this.ShowMessageAsync("Informacion", "Datos Cargados.");

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);

            }
        }

        private async void btneditpedi_Click(object sender, RoutedEventArgs e)
        {
            //editar
            try
            {
               
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }
    }
}
