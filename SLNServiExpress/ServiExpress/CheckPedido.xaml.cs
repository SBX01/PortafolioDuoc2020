using BLL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
    /// Lógica de interacción para CheckPedido.xaml
    /// </summary>
    public partial class CheckPedido : MetroWindow
    {
        DetallePedidoBLL detalleActual = new DetallePedidoBLL();
        public CheckPedido()
        {
            InitializeComponent();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            RegistroPedido pp = new RegistroPedido();
            this.Close();
            pp.Show();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ListarDatos();
                //DesactivarBotones();
            }
            catch (Exception)
            {

               
            }
            dgDetalle.IsReadOnly = true;
        }

        private void ListarDatos()
        {
            // se carga el combo box segun rut empleado activo
            List<int> listaIdPedido = new List<int>();
            listaIdPedido = new PedidoBLL().listarid(Data.RutEmpleadoActivo);
            cboPedido.ItemsSource = listaIdPedido;
            cboPedido.SelectedIndex = 0;

            int id = int.Parse(cboPedido.SelectedItem.ToString());
            // carga la tabla con detalle de pedido segun el combo
            var listaDetalle = new DetallePedidoBLL().listar();
            var segunId = (from detalle in listaDetalle
                           where detalle.IdPedido == id & detalle.Estado != EstadoPedido.Finalizado
                           select detalle).ToList();
            dgDetalle.ItemsSource = segunId;
        }

        private async void dgDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                detalleActual = (DetallePedidoBLL)dgDetalle.SelectedItem;
                await this.ShowMessageAsync("Atencion", "Ha seleccionado el producto N° " + detalleActual.IdProducto + ".");
                //ActivarBotones();
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Informacion", "No ha seleccionado ningun producto");

            }

        }

        private void cboPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = int.Parse(cboPedido.SelectedItem.ToString());
                // carga la tabla con detalle de pedido segun el combo
                var listaDetalle = new DetallePedidoBLL().listar();
                var segunId = (from detalle in listaDetalle
                               where detalle.IdPedido == id & detalle.Estado != EstadoPedido.Finalizado
                               select detalle).ToList();
                dgDetalle.ItemsSource = segunId;
            }
            catch (Exception)
            {

               
            }

        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (txtComentario.IsEnabled == false)
                {
                    txtComentario.IsEnabled = true;
                    await this.ShowMessageAsync("Informacion", "Ahora puede agregar un comentario.");
                }
                else
                {
                    switch (await this.ShowMessageAsync("Informacion", "¿Esta seguro de los cambios?", MessageDialogStyle.AffirmativeAndNegative))
                    {
                        case MessageDialogResult.Affirmative:
                            detalleActual.Comentario = txtComentario.Text;
                            detalleActual.Estado = EstadoPedido.Rechazado;
                            detalleActual.modificar();
                            await this.ShowMessageAsync("Informacion", "Detalle mofidicado.");
                            txtComentario.IsEnabled = false;
                            txtComentario.Text = string.Empty;
                            ListarDatos();
                            detalleActual = null;
                            break;
                        case MessageDialogResult.Negative:
                            await this.ShowMessageAsync("Informacion", "Cambios cancelados.");
                            txtComentario.Text = string.Empty;
                            txtComentario.IsEnabled = false;
                            break;
                    }

                }
               
            }
            catch (Exception)
            {

                await this.ShowMessageAsync("Informacion", "No ha seleccionado ningun producto");
            }
        }
        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (await this.ShowMessageAsync("Informacion", "¿Esta seguro de que está todo correcto?",MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Cambios cancelados.");
                        break;
                    case MessageDialogResult.Affirmative:

                        List<DetallePedidoBLL> detalle = (List<DetallePedidoBLL>)dgDetalle.ItemsSource;

                        foreach (var d in detalle)
                        {

                            ProductoBLL producto = (from pr in new ProductoBLL().ListarTodo()
                                                    where pr.Id_producto == d.IdProducto
                                                    select pr).FirstOrDefault();

                            d.Estado = EstadoPedido.Finalizado;
                            d.modificar();

                            producto.Stock_produc = producto.Stock_produc + detalleActual.Cantidad;
                            producto.Modificar();
                        }
                        if(detalle.Count  != 0)
                        {
                            await this.ShowMessageAsync("Informacion", "Cambios guardados");
                            //DesactivarBotones();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Informacion", "No se encuentran datos");
                        }
                        
                       

                        break;

                }
                

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", ex.Message);

            }
            ListarDatos();
        }

        private async void btnAceptardetalle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (await this.ShowMessageAsync("Informacion", "¿Esta seguro de los cambios?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        ProductoBLL producto = (from pr in new ProductoBLL().ListarTodo()
                                                where pr.Id_producto == detalleActual.IdProducto
                                                select pr).FirstOrDefault();
                        if (detalleActual.Estado != EstadoPedido.Finalizado)
                        {
                            producto.Stock_produc = producto.Stock_produc + detalleActual.Cantidad;
                            producto.Modificar();
                            detalleActual.Estado = EstadoPedido.Finalizado;
                            detalleActual.modificar();
                            await this.ShowMessageAsync("Informacion", "Cambios guardados");
                        }
                        break;
                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Cambios cancelados");
                        break;
                }


                

                detalleActual = null;
                ListarDatos();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", ex.Message);

            }
           
        }

        private void dgDetalle_MouseEnter(object sender, MouseEventArgs e)
        {
            dgDetalle.ToolTip = "Seleccione un producto y luego seleccione el icono del lápiz para agregar un comentario";
            
        }

        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (await this.ShowMessageAsync("Informacion", "¿Está seguro que todo esta incorrecto?", MessageDialogStyle.AffirmativeAndNegative))
                {

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Cambios cancelados.");
                        break;
                    case MessageDialogResult.Affirmative:

                        List<DetallePedidoBLL> detalle = (List<DetallePedidoBLL>)dgDetalle.ItemsSource;

                        foreach (var d in detalle)
                        {
                            d.Estado = EstadoPedido.Rechazado;
                            d.Comentario = "Presenta detalle";
                            d.modificar();
                        }
                        if (detalle.Count != 0)
                        {
                            await this.ShowMessageAsync("Informacion", "Cambios guardados");
                            //DesactivarBotones();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Informacion", "No se encuentran datos");
                        }

                        break;

                }


            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", ex.Message);

            }
            ListarDatos();
        }

        private async void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (await this.ShowMessageAsync("Informacion", "¿Esta seguro de los cambios?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        detalleActual.Estado = EstadoPedido.Rechazado;
                        detalleActual.modificar();
                        await this.ShowMessageAsync("Informacion", "Cambios guardados");
                        break;
                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Cambios cancelados");
                        break;
                }
               
                ListarDatos();

                detalleActual = null;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", ex.Message);

            }
           
        }
        /*
         *     Funcionalidades no requeridas         
         *      revisar bien si realmente es necesario su uso
         */
        //void ActivarBotones()
        //{
        //    btnAceptar.IsEnabled = true;
        //    btnCancelar.IsEnabled = true;
        //}

        //void DesactivarBotones()
        //{
        //    btnAceptar.IsEnabled = false ;
        //    btnCancelar.IsEnabled = false;
        //}

        private void gridAyuda_MouseEnter(object sender, MouseEventArgs e)
        {
            gridAyuda.ToolTip = "Para activar los botones, seleccione un producto.";
        }
    }
}
