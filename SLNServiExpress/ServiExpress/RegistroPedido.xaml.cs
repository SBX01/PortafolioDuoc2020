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
        int idPedido = 0;
        public RegistroPedido()
        {
            InitializeComponent();
            dgDetalleProducto.IsReadOnly = true;
            dgDetalle.IsReadOnly = true;
        }


        private async void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            DetallePedidoBLL detalleNuevo = new DetallePedidoBLL();
            if (idPedido.Equals(0))
            {
                throw new Exception("Seleccione un pedido antes de agregar un detalle");
            }
            try
            {
                detalleNuevo.IdPedido = idPedido;
                detalleNuevo.IdProducto =long.Parse(cboProductos.SelectedValue.ToString()) ;
                detalleNuevo.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                detalleNuevo.Cantidad = int.Parse(txtCantidadDetalle.Text);
                detalleNuevo.Estado = (EstadoPedido)cboEstado.SelectedValue;
                detalleNuevo.Comentario = txtComentarios.Text;
                detalleNuevo.agregar();
                
                await this.ShowMessageAsync("Información","El detalle ha sido registrado");

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            limpiar();
            ListarDetalleProducto();
        }

        private async void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (idPedido.Equals(0))
            {
                throw new Exception("Seleccione un pedido antes de agregar un detalle");
            }
            try
            {
                long idProducto = long.Parse(cboProductos.SelectedValue.ToString());
                switch (await this.ShowMessageAsync("Información","¿Está seguro que desea Eliminar el detalle?",MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Información", "Acción cancelada.");
                        break;
                    case MessageDialogResult.Affirmative:
                        pedidoActual.eliminar(cboEmpleado.SelectedValue.ToString(), idProducto, idPedido);
                        
                        await this.ShowMessageAsync("Información", "El detalle ha sido eliminado.");
                        break;

                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }

            limpiar();
            ListarDetalleProducto();
        }

        public void dgproduc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private async void btnEditarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (idPedido.Equals(0))
            {
                throw new Exception("Seleccione un pedido antes de agregar un detalle");
            }
            DetallePedidoBLL editar = new DetallePedidoBLL();
            try
            {
                switch (await this.ShowMessageAsync("Información", "¿Está segure que desea modificar este detalle?",MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Información", "Acción cancelada.");
                        break;
                    case MessageDialogResult.Affirmative:
                        editar.IdPedido = idPedido;
                        editar.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                        editar.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                        editar.Cantidad = int.Parse(txtCantidadDetalle.Text);
                        editar.Estado = (EstadoPedido)cboEstado.SelectedValue;
                        editar.Comentario = txtComentarios.Text;

                        editar.modificar();
                        await this.ShowMessageAsync("Información", "El detalle ha sido modificado");
                        break;

                }
                
            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            ListarDetalleProducto();
            limpiar();
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
            limpiar();
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
                if (dgDetalleProducto.ItemsSource != null)
                {
                    iniciar(true);
                }
                else
                {
                    iniciar(false);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Excepcion producida :C ... Error: " + ex.Message);
            }

            ListarDetalleProducto();

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
            cboProductos.DisplayMemberPath = "Descripcion";
            cboProductos.SelectedValuePath = "Id_producto";
            cboProductos.SelectedIndex = 0;

            var estados = (EstadoPedido[])Enum.GetValues(typeof(EstadoPedido));
            cboEstado.ItemsSource = estados;
            cboEstado.SelectedIndex = 0;

        }

        private void ListarDetalleProducto()
        {
            List<DetallePedidoBLL> listaDetallepedido = new DetallePedidoBLL().listar();
            var listaDetalle = (from dt in listaDetallepedido
                                where dt.IdPedido == idPedido
                                select dt).ToList();
            dgDetalle.ItemsSource = listaDetalle;
        }

        private void checkAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (checkAgregar.IsChecked == true)
            {
                agregarDetalle = false;
                iniciar(agregarDetalle);

                cboProveedor.IsEnabled = false;
                cboEmpleado.IsEnabled = false;
                tbDescripcion.IsEnabled = false;
            }
            if (checkAgregar.IsChecked == false)
            {
                agregarDetalle = true;
                iniciar(agregarDetalle);

                cboProveedor.IsEnabled = true;
                cboEmpleado.IsEnabled = true;
                tbDescripcion.IsEnabled = true;
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
                detalle = (DetallePedidoBLL)dgDetalle.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar este detalle del Pedido N°: " + detalle.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        idPedido = detalle.IdPedido;
                        cboProductos.SelectedValue = detalle.IdProducto;
                        cboEstado.SelectedValue = detalle.Estado;
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
            // se selecciona un pedido desde la tabla haciendo doble click
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
                        ListarDetalleProducto();
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
            //editar, se toman los datos y se modifican
            try
            {
                PedidoBLL editar = new PedidoBLL();
                editar.IdPedido = idPedido;
                editar.Fecha = DateTime.Now;
                editar.Descripcion = tbDescripcion.Text;
                editar.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                editar.RutProveedor = cboProveedor.SelectedValue.ToString();
                switch (await this.ShowMessageAsync("Atencion", "¿Está seguro que desea modificar el Pedido N°: " + editar.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        editar.Modificar();
                        await this.ShowMessageAsync("Informacion", "El Pedido ha sido modificado", style: MessageDialogStyle.Affirmative);

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
                
                dgDetalleProducto.ItemsSource = new PedidoBLL().listar();
                


            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
            limpiar();
        }

        private async void btnelimped_Click(object sender, RoutedEventArgs e)
        {
            PedidoBLL eliminar = new PedidoBLL();
            try
            {
                switch (await this.ShowMessageAsync("Atencion", "El pedido a eliminar es el pedido N°" + idPedido + ". \n Haga doble click en otro pedido, en la tabla de pedidos para selecionarlo. \n ¿Desea Eliminar este pedido?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    // si la respuesta es positiva pasa al affirmative si no se cancela y termina la accion
                    case MessageDialogResult.Affirmative:
                        switch (await this.ShowMessageAsync("Atencion", "¿Está seguro que desea eliminar el pedido N°"+ idPedido +"? \n Esta acción no se puede revertir", MessageDialogStyle.AffirmativeAndNegative))
                        {
                            // si la respuesta es positiva pasa al affirmative si no se cancela y termina la accion
                            case MessageDialogResult.Negative:
                                await this.ShowMessageAsync("Cancelado", "Acción cancelada.", style: MessageDialogStyle.Affirmative);

                                break;
                            case MessageDialogResult.Affirmative:
                                // aqui se elimina el pedido y se vuelve a listar.
                                eliminar.Eliminar(idPedido);
                                await this.ShowMessageAsync("Atención", "El pedido ha sido eliminado.", style: MessageDialogStyle.Affirmative);
                                dgDetalleProducto.ItemsSource = eliminar.listar();
                                tbDescripcion.Text = string.Empty;
                                break;


                        }
                        break;
                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Cancelado", "Acción cancelada.", style: MessageDialogStyle.Affirmative);
                        break;
                }
                            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }

            limpiar();
        }

        void limpiar()
        {
            cboEmpleado.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            cboProductos.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;

            tbDescripcion.Text = string.Empty;
            txtCantidadDetalle.Text = string.Empty;
            txtComentarios.Text = string.Empty;
        }
    }

    
}
