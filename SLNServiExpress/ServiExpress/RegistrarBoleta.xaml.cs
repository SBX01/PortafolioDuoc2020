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
using MahApps.Metro.Controls.Dialogs;

namespace ServiExpress
{
    /// <summary>
    /// Lógica de interacción para RegistrarBoleta.xaml
    /// </summary>
    public partial class RegistrarBoleta : MetroWindow
    {
        DetalleBoletaBLL detalleActual = new DetalleBoletaBLL();
        List<DetalleBoletaBLL> ListaDetalleBoleta = new List<DetalleBoletaBLL>();
        BoletaBLL boletaActual = new BoletaBLL();
        bool agregarDetalle = false;
        int idBoleta = 0;
        int idServicio = 0;
        int indice;

        public RegistrarBoleta()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            var Tpago = (Tipopago[])Enum.GetValues(typeof(Tipopago));
            cmbopago.ItemsSource = Tpago;
            cmbopago.SelectedIndex = 0;

            fechaboleta.Text = DateTime.Now.ToString();
        }

        private void checkAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (checkAgregar.IsChecked == true)
            {
                agregarDetalle = false;
                GridBoleta.Visibility = Visibility.Hidden;

            }
            else
            {
                agregarDetalle = true;
                GridBoleta.Visibility = Visibility.Visible;
            }
        }

        private async void dgDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Carga El detalle de la boleta
            try
            {

                detalleActual = (DetalleBoletaBLL)dgDetalleboleta.SelectedItem;
                switch (await this.ShowMessageAsync("Atencion", "¿Quiere exportar Datos del boleta N°: " + detalleActual.Id_Boleta + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        indice = ListaDetalleBoleta.IndexOf(detalleActual);
                        idBoleta = detalleActual.Id_Boleta;
                        //  txtCantidadServicio.Text = boleta.cantidad
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

        private async void btneditbole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BoletaBLL editar = new BoletaBLL();
                editar.IdBoleta = idBoleta;
                editar.Fechaboleta = DateTime.Now;
                editar.TotalBoleta = int.Parse(txttotalbol.Text);
                // editar.TipoPago = (TipoPago)
                switch (await this.ShowMessageAsync("Atencion", "¿Está seguro que desea modificar la boleta N°: " + editar.IdBoleta + " ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:

                        editar.Modificar();
                        await this.ShowMessageAsync("Informacion", "la boleta ha sido modificado", style: MessageDialogStyle.Affirmative);

                        break;

                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("Informacion", "Accion cancelada.");
                        break;
                }
                dgDetalleboleta.ItemsSource = new BoletaBLL().listar();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }

        private async void btnagregarbolet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                boletaActual.Fechaboleta = DateTime.Now;
                boletaActual.TotalBoleta = int.Parse(txttotalbol.Text);

                boletaActual.Agregar();
                //dgDetalleboleta.ItemsSource = new BoletaBLL().listar(); // funcionalidad no lista
                await this.ShowMessageAsync("Informacion", "La Boleta ha sido creada! \n ahora puede agregar detalle a su boleta", style: MessageDialogStyle.Affirmative);

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error", "Lo sentimos ha ocurrido un error. \n Error: " + ex.Message, style: MessageDialogStyle.Affirmative);
            }
        }

        private async void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            //Agregar Detalle
            DetalleBoletaBLL detalleNuevo = new DetalleBoletaBLL();
            
            try
            {
                if (idBoleta.Equals(0))
                {
                    throw new Exception("Seleccione una boleta antes de agregar detalle");
                }
                detalleNuevo.Id_Boleta = idBoleta;
                detalleNuevo.Id_Servicio = idServicio;
                detalleNuevo.Cantidad_Servicio = int.Parse(txtCantidadServicio.Text);
                detalleNuevo.Valor = int.Parse(txtvalor.Text);
                ListaDetalleBoleta.Add(detalleNuevo);


                await this.ShowMessageAsync("Informacion", "El detalle  ha sido registrado");

            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("informacion", "Error :" + ex.Message);
            }
            dgDetalleboleta.ItemsSource = null;
            dgDetalleboleta.ItemsSource = ListaDetalleBoleta;
        }

        private async void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            // Eliminar Detalle
            try
            {
                ListaDetalleBoleta.Remove(detalleActual);
            }
            catch(Exception ex)
            {
                await this.ShowMessageAsync("informacion", "Error :" + ex.Message);
            }
            dgDetalleboleta.ItemsSource = null;
            dgDetalleboleta.ItemsSource = ListaDetalleBoleta;
        }

        private async void btnEditarDetalle_Click(object sender, RoutedEventArgs e)
        {
            DetalleBoletaBLL editar = new DetalleBoletaBLL();

            try
            {

                switch (await this.ShowMessageAsync("Informacion", "¿desea modificar este detalle ?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Negative:
                        await this.ShowMessageAsync("informacion", "Accion cancelada");
                        break;
                    case MessageDialogResult.Affirmative:
                        editar.Id_Boleta = idBoleta;
                        editar.Id_Servicio = idServicio;
                        editar.Cantidad_Servicio = int.Parse(txtCantidadServicio.Text);
                        editar.Valor = int.Parse(txtvalor.Text);

                        ListaDetalleBoleta.Insert(indice,editar);
                        await this.ShowMessageAsync("informacion", "el detalle ha sido modificado");
                        break;

                }

            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Información", "Error: " + ex.Message);
            }
            dgDetalleboleta.ItemsSource = null;
            dgDetalleboleta.ItemsSource = ListaDetalleBoleta;
        }

        private async void Btnelimproduc_Click(object sender, RoutedEventArgs e)
        {
            // La boleta no se elimina(?
            BoletaBLL eliminar = new BoletaBLL();
            try
            {
                switch (await this.ShowMessageAsync("Atencion", "la boleta a eliminar es el  N°" + idBoleta + ". \n Haga doble click en otro pedido, en la tabla de boletas para selecionarlo. \n ¿Desea Eliminar este pedido?", MessageDialogStyle.AffirmativeAndNegative))
                {
                    case MessageDialogResult.Affirmative:
                        switch (await this.ShowMessageAsync("Atencion", "¿Está seguro que desea eliminar la boleta N°" + idBoleta + "? \n Esta acción no se puede revertir", MessageDialogStyle.AffirmativeAndNegative))
                        {
                            // si la respuesta es positiva pasa al affirmative si no se cancela y termina la accion
                            case MessageDialogResult.Negative:
                                await this.ShowMessageAsync("Cancelado", "Acción cancelada.", style: MessageDialogStyle.Affirmative);

                                break;
                            case MessageDialogResult.Affirmative:
                                // aqui se elimina el pedido y se vuelve a listar.
                                eliminar.Eliminar(idBoleta);
                                await this.ShowMessageAsync("Atención", "la boleta ha sido eliminado.", style: MessageDialogStyle.Affirmative);
                                dgDetalleboleta.ItemsSource = eliminar.listar();

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
        }

        private void Btnlistarproduc_Click(object sender, RoutedEventArgs e)
        {
            dgBoleta.ItemsSource = null;
            dgBoleta.ItemsSource = new BoletaBLL().listar();
        }

        private void Btnatras_Click(object sender, RoutedEventArgs e)
        {
            ModuloFinanzas ventana = new ModuloFinanzas();
            this.Close();
            ventana.Show();
        }
    }
}
