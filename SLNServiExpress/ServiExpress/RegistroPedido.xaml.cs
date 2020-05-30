using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistroPedido.xaml
    /// </summary>
    public partial class RegistroPedido : MetroWindow
    {
        int indice;
        DetallePedidoBLL pedidoActual = new DetallePedidoBLL();
        List<DetallePedidoBLL> ListaDetallePedidos = new List<DetallePedidoBLL>();
        PedidoBLL pedido = new PedidoBLL();
        bool agregarDetalle = false;
        int idPedido = 0;
        string rutEmpleado;

        public RegistroPedido()
        {
            InitializeComponent();
            dgDetalleProducto.IsReadOnly = true;
            dgDetalle.IsReadOnly = true;
            cboEstado.IsEnabled = false;
        }


        private async void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            DetallePedidoBLL detalleNuevo = new DetallePedidoBLL();
            
            try
            {
                if (string.IsNullOrEmpty(rutEmpleado))
                {
                    // si esta vacio es porque es un nuevo pedido
                    detalleNuevo.IdPedido = idPedido;
                    detalleNuevo.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                    detalleNuevo.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                    detalleNuevo.Cantidad = int.Parse(txtCantidadDetalle.Text);
                    detalleNuevo.Estado = (EstadoPedido)cboEstado.SelectedValue;
                    detalleNuevo.Comentario = " ";
                    ListaDetallePedidos.Add(detalleNuevo);
                }
                else
                {
                    if (rutEmpleado == cboEmpleado.SelectedValue.ToString())
                    {
                        detalleNuevo.IdPedido = idPedido;
                        detalleNuevo.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                        detalleNuevo.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                        detalleNuevo.Cantidad = int.Parse(txtCantidadDetalle.Text);
                        detalleNuevo.Estado = (EstadoPedido)cboEstado.SelectedValue;
                        detalleNuevo.Comentario = " ";
                        ListaDetallePedidos.Add(detalleNuevo);
                    }
                    else
                    {
                        string comentario = " ";
                        detalleNuevo.IdPedido = idPedido;
                        detalleNuevo.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                        detalleNuevo.RutEmpleado = pedidoActual.RutEmpleado;
                        detalleNuevo.Cantidad = int.Parse(txtCantidadDetalle.Text);
                        detalleNuevo.Estado = (EstadoPedido)cboEstado.SelectedValue;
                        detalleNuevo.Comentario = comentario + " (Editado por Administrador)";
                        ListaDetallePedidos.Add(detalleNuevo);
                    }
                }
               
                


                
                await this.ShowMessageAsync("Información","El detalle ha sido registrado");

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            limpiarDetalle();
            dgDetalle.ItemsSource = null;
            dgDetalle.ItemsSource = ListaDetallePedidos;
        }

        private async void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (idPedido.Equals(0))
                {
                   // throw new Exception("Seleccione un pedido antes de agregar un detalle");
                }
                long idProducto = long.Parse(cboProductos.SelectedValue.ToString());
                switch (await this.ShowMessageAsync("Información","¿Está seguro que desea Eliminar el detalle?",MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Información", "Acción cancelada.");
                        break;
                    case MessageDialogResult.Affirmative:
                        if (rutEmpleado == cboEmpleado.SelectedValue.ToString())
                        {
                            ListaDetallePedidos.Remove(pedidoActual);
                            pedidoActual.eliminar(pedidoActual.RutEmpleado, pedidoActual.IdProducto, pedidoActual.IdPedido);
                        }
                        
                        
                        await this.ShowMessageAsync("Información", "El detalle ha sido eliminado.");
                        break;

                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            limpiarDetalle();
            dgDetalle.ItemsSource = null;
            dgDetalle.ItemsSource = ListaDetallePedidos;
        }

        public void dgproduc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private async void btnEditarDetalle_Click(object sender, RoutedEventArgs e)
        {
           
            DetallePedidoBLL editar = new DetallePedidoBLL();
            try
            {
                if (idPedido.Equals(0))
                {
                   // throw new Exception("Seleccione un pedido antes de agregar un detalle");
                }
                switch (await this.ShowMessageAsync("Información", "¿Está segure que desea modificar este detalle?",MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Información", "Acción cancelada.");
                        break;
                    case MessageDialogResult.Affirmative:

                        if (rutEmpleado == cboEmpleado.SelectedValue.ToString())
                        {
                            editar.IdPedido = idPedido;
                            editar.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                            editar.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                            editar.Cantidad = int.Parse(txtCantidadDetalle.Text);
                            editar.Estado = (EstadoPedido)cboEstado.SelectedValue;
                            editar.Comentario = " ";

                            ListaDetallePedidos.RemoveAt(indice);
                            ListaDetallePedidos.Insert(indice, editar);
                            editar.modificar();
                        }
                        else
                        {
                            string comentario = " ";
                            editar.IdPedido = idPedido;
                            editar.IdProducto = long.Parse(cboProductos.SelectedValue.ToString());
                            editar.RutEmpleado = rutEmpleado;
                            editar.Cantidad = int.Parse(txtCantidadDetalle.Text);
                            editar.Estado = (EstadoPedido)cboEstado.SelectedValue;
                            editar.Comentario = comentario + " (Editado por Administrador)";

                            ListaDetallePedidos.RemoveAt(indice);
                            ListaDetallePedidos.Insert(indice, editar);
                            editar.modificar();
                        }
                        
                        await this.ShowMessageAsync("Información", "El detalle ha sido modificado");
                        break;

                }
                
            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            dgDetalle.ItemsSource = null;
            dgDetalle.ItemsSource = ListaDetallePedidos;
            limpiarDetalle();
        }

        private async void btnagregarped_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Data.EsAdmin)
                {
                    pedido = new PedidoBLL();
                    pedido.Fecha = DateTime.Now;
                    pedido.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                    pedido.Descripcion = tbDescripcion.Text + " (Administrador)";
                    pedido.RutProveedor = cboProveedor.SelectedValue.ToString();
                    pedido.Agregar(ListaDetallePedidos);
                }
                else
                {
                    pedido = new PedidoBLL();
                    pedido.Fecha = DateTime.Now;
                    pedido.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                    pedido.Descripcion = tbDescripcion.Text + " ";
                    pedido.RutProveedor = cboProveedor.SelectedValue.ToString();
                    pedido.Agregar(ListaDetallePedidos);
                }
               
                ListarPedidos();
                await this.ShowMessageAsync("Informacion", "El Pedido ha sido creado!", style: MessageDialogStyle.Affirmative);

            }

            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " +ex.Message, style: MessageDialogStyle.Affirmative);
            }
            limpiarPedido();
            ListaDetallePedidos.Clear();
            dgDetalle.ItemsSource = null;
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
            IniciarVentana();

        }

        private void IniciarVentana()
        {
            try
            {


                cboProveedor.ItemsSource = new ProveedorBLL().listarTodos();
                cboProveedor.DisplayMemberPath = "nombreCompleto";
                cboProveedor.SelectedValuePath = "Rut";
                cboProveedor.SelectedIndex = 0;


                List<EmpleadoBLL> listadoEmpleados = new EmpleadoBLL().listarTodos();
                if (Data.EsAdmin)
                {
                    var listaBodegueros = (from emp in listadoEmpleados
                                           where (emp.CARGO_EMPL == Cargos.Bodeguero || emp.CARGO_EMPL == Cargos.Administrador) & emp.ID_USUARIO == Data.IdUserActivo
                                           select emp).ToList();
                    cboEmpleado.ItemsSource = listaBodegueros;
                }
                else
                {
                    var listaBodegueros = (from emp in listadoEmpleados
                                           where (emp.CARGO_EMPL == Cargos.Bodeguero) & emp.ID_USUARIO == Data.IdUserActivo
                                           select emp).ToList();
                    cboEmpleado.ItemsSource = listaBodegueros;
                }

                cboEmpleado.DisplayMemberPath = "nombreCompleto";
                cboEmpleado.SelectedValuePath = "RUT_EMPL";
                cboEmpleado.SelectedIndex = 0;
                cboEmpleado.IsEnabled = false;

                cboProductos.ItemsSource = new ProductoBLL().ListarTodo();
                cboProductos.DisplayMemberPath = "Descripcion";
                cboProductos.SelectedValuePath = "Id_producto";
                cboProductos.SelectedIndex = 0;

                var estados = (EstadoPedido[])Enum.GetValues(typeof(EstadoPedido));
                cboEstado.ItemsSource = estados;
                cboEstado.SelectedIndex = 0;

                List<PedidoBLL> listar = pedido.listar();
                var listadoPedidos = (from pedido in listar
                                      where pedido.RutEmpleado == cboEmpleado.SelectedValue.ToString()
                                      select pedido).ToList();
                dgDetalleProducto.ItemsSource = listadoPedidos;

                iniciar(true);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Excepcion producida :C ... Error: " + ex.Message);
            }
        }

        private void ListarDetalleProducto(int idpedidofk,string rutEmpleado)
        {
            List<DetallePedidoBLL> listaDetallepedido = new DetallePedidoBLL().listar();
            var listaDetalle = (from dt in listaDetallepedido
                                where dt.IdPedido == idpedidofk
                                select dt).ToList();
            ListaDetallePedidos = listaDetalle;
            dgDetalle.ItemsSource = listaDetalle;
        }

        private void checkAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (checkAgregar.IsChecked == true)
            {
                agregarDetalle = false;
                iniciar(agregarDetalle);
                lbListaDetalle.Content = "Detalle Pedido";

                cboProveedor.IsEnabled = false;
                cboEmpleado.IsEnabled = false;
                //tbDescripcion.IsEnabled = false;
            }
            if (checkAgregar.IsChecked == false)
            {
                agregarDetalle = true;
                iniciar(agregarDetalle);
                lbListaDetalle.Content = "Lista detalle";
                cboProveedor.IsEnabled = true;
                //cboEmpleado.IsEnabled = true;
                tbDescripcion.IsEnabled = true;
            }

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
               

                pedidoActual = (DetallePedidoBLL)dgDetalle.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar este detalle del Pedido N°: " + pedidoActual.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        indice = ListaDetallePedidos.IndexOf(pedidoActual);
                        idPedido = pedidoActual.IdPedido;
                        cboProductos.SelectedValue = pedidoActual.IdProducto;
                        cboEstado.SelectedValue = pedidoActual.Estado;
                        txtCantidadDetalle.Text = pedidoActual.Cantidad.ToString();
                        // Comentario irá en el check
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
                        if(pedido.RutEmpleado == cboEmpleado.SelectedValue.ToString())
                        {
                            idPedido = pedido.IdPedido;
                            cboEmpleado.SelectedValue = pedido.RutEmpleado;
                            cboProveedor.SelectedValue = pedido.RutProveedor;
                            tbDescripcion.Text = pedido.Descripcion;
                            ListarDetalleProducto(idPedido, pedido.RutEmpleado);
                        }
                        else
                        {
                            idPedido = pedido.IdPedido;
                            rutEmpleado = pedido.RutEmpleado;
                            cboProveedor.SelectedValue = pedido.RutProveedor;
                            tbDescripcion.Text = pedido.Descripcion;
                            ListarDetalleProducto(idPedido, pedido.RutEmpleado);
                        }
                        
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
                if (Data.EsAdmin)
                {
                    editar.IdPedido = idPedido;
                    editar.Fecha = DateTime.Now;
                    editar.Descripcion = tbDescripcion.Text + "(Modificado por " + Data.NombreUser + ")";
                    editar.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                    editar.RutProveedor = cboProveedor.SelectedValue.ToString();
                }
                else
                {
                    editar.IdPedido = idPedido;
                    editar.Fecha = DateTime.Now;
                    editar.Descripcion = tbDescripcion.Text + "(Modificado por "+ Data.NombreUser +")";
                    editar.RutEmpleado = cboEmpleado.SelectedValue.ToString();
                    editar.RutProveedor = cboProveedor.SelectedValue.ToString();
                }
                
                switch (await this.ShowMessageAsync("Atencion", "¿Está seguro que desea modificar el Pedido N°: " + editar.IdPedido + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        editar.Modificar(ListaDetallePedidos);
                        await this.ShowMessageAsync("Informacion", "El Pedido ha sido modificado", style: MessageDialogStyle.Affirmative);

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }

                ListarPedidos();



            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
            limpiarPedido();
            ListaDetallePedidos.Clear();
            dgDetalle.ItemsSource = ListaDetallePedidos;
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
                                eliminar.EliminarPedido(idPedido);
                                await this.ShowMessageAsync("Atención", "El pedido ha sido eliminado.", style: MessageDialogStyle.Affirmative);
                                ListarPedidos();
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

            limpiarPedido();
            ListaDetallePedidos.Clear();
            dgDetalle.ItemsSource = null;
        }

        void limpiarPedido()
        {
            cboEmpleado.SelectedIndex = 0;
            cboProductos.SelectedIndex = 0;
            tbDescripcion.Text = string.Empty;

        }
        void limpiarDetalle()
        {
            
            cboProductos.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtCantidadDetalle.Text = string.Empty;
            
        }

        private void cboProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListarPedidos();

        }

        private void ListarPedidos()
        {
            var aBuscar = cboProveedor.SelectedValue.ToString();
            List<PedidoBLL> listaPedidos = new PedidoBLL().listar();
            // listar pedido segun el proveedor
            if (Data.EsAdmin)
            {

                var listaSegunProveedor = (from pedido in listaPedidos
                                           where pedido.RutProveedor == aBuscar
                                           select pedido).ToList();
                dgDetalleProducto.ItemsSource = null;
                dgDetalleProducto.ItemsSource = listaSegunProveedor;
            }
            else
            {
                var listaSegunProveedor = (from pedido in listaPedidos
                                           
                                           where pedido.RutProveedor == aBuscar & pedido.RutEmpleado == Data.RutEmpleadoActivo
                                           select pedido).ToList();
                dgDetalleProducto.ItemsSource = null;
                dgDetalleProducto.ItemsSource = listaSegunProveedor;
            }
        }


        private void btnlistarped_Click(object sender, RoutedEventArgs e)
        {
            if (Data.EsAdmin)
            {
                dgDetalleProducto.ItemsSource = null;
                dgDetalleProducto.ItemsSource = new PedidoBLL().listar();
            }
            else
            {
                List<PedidoBLL> listaPedidos = new PedidoBLL().listar();
                var listaSegunProveedor = (from pedido in listaPedidos
                                           where pedido.RutEmpleado == cboEmpleado.SelectedValue.ToString()
                                           select pedido).ToList();
                dgDetalleProducto.ItemsSource = null;
                dgDetalleProducto.ItemsSource = listaSegunProveedor;
            }
            iniciar(true);
            ListaDetallePedidos.Clear();
            lbListaDetalle.Content = "Lista detalle";
            checkAgregar.IsChecked = false;
            cboProveedor.IsEnabled = true;
            dgDetalle.ItemsSource = null;
            limpiarPedido();
            limpiarDetalle();
            Console.WriteLine("Todo limpio ,Elementos lista: " + ListaDetallePedidos.Count);
        }
    }

    
}
