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
using BibliotecaClientes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para AdminClientes.xaml
    /// </summary>
    
    public partial class AdminClientes : MetroWindow
    {
        Ventana_Principal vp = new Ventana_Principal();
        public AdminClientes()
        {
            
            InitializeComponent();
            CargaCombo();
        }

        private void CargaCombo()
        {
            cboActividad.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cboActividad.SelectedIndex = 0;
            cboTIpo.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cboTIpo.SelectedIndex = 0;
        }


        private async void btnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            //agregar if pa confirmar q todos los campos esten completos

            if (!string.IsNullOrWhiteSpace(txtRut.Text) && !string.IsNullOrWhiteSpace(txtNomContacto.Text) && !string.IsNullOrWhiteSpace(txtRazonSocial.Text) && !string.IsNullOrWhiteSpace(txtMailContact.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text) && cboActividad.SelectedIndex!=0 && cboTIpo.SelectedIndex!=0 )
            {
                //if para la alerta si es que el cliente esta registrado
                if (Ventana_Principal.listaClientes.Existe(int.Parse(txtRut.Text)))
                {
                    await this.ShowMessageAsync("Alerta:",
                        string.Format("El Cliente con Rut: {0}, ya existe!!", txtRut.Text));
                }
                else
                {
                    Cliente cliente = new Cliente
                    {
                        Rut = int.Parse(txtRut.Text),
                        RazonSocial = txtRazonSocial.Text,
                        NombreContacto = txtNomContacto.Text,
                        MailContacto = txtMailContact.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = int.Parse(txtTelefono.Text),
                        TipoEmpresa = (TipoEmpresa)cboTIpo.SelectedValue,
                        ActividadEmpresa = (ActividadEmpresa)cboActividad.SelectedValue
                    };
                    Ventana_Principal.listaClientes.Add(cliente);
                    await this.ShowMessageAsync("Confirmacion:",
                        string.Format("El Cliente con Rut: {0}, fue agregado con exito!!", txtRut.Text));

                }
            }
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe Completar todos los datos");
            }



            
            



        }

        private void btnAztualizClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientesAuxiliar listar = new ListadoClientesAuxiliar();
            this.Close();
            listar.Show();
        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Principal vp = new Ventana_Principal();
            this.Close();
            vp.Show();

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {
            //variable que convierte que cambia los parametros de escojer color..
            var bc = new BrushConverter();
            if (switchCambioBack.IsChecked == true)
            {
                ListadoClientesMenu listm = new ListadoClientesMenu();
                listm.switchCambioBack.IsChecked = true;
                this.Background = Brushes.Black;
                switchCambioBack.Foreground = Brushes.White;
                switchCambioBack.ThumbIndicatorBrush = Brushes.White;
                this.btnLimpiar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
                //this.btnLimpiar.Foreground = Brushes.Black;
                this.lblTitulo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblTIpo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                lblRazonSocial.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblMailContact.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblNomContact.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblctividad.Foreground=(Brush)bc.ConvertFrom("#2b78e4");
                this.lblTelefon.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.lblDireccion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
                this.brSeparador.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
                this.brSeparador.Background = (Brush)bc.ConvertFrom("#2b78e4");
            }

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            this.btnLimpiar.BorderBrush = Brushes.Black;
            this.lblTitulo.Foreground = Brushes.Black;
            this.lblTIpo.Foreground = Brushes.Black;
            lblRazonSocial.Foreground = Brushes.Black;
            this.lblMailContact.Foreground = Brushes.Black;
            this.lblRut.Foreground = Brushes.Black;
            this.lblNomContact.Foreground = Brushes.Black;
            this.lblctividad.Foreground = Brushes.Black;
            this.lblTelefon.Foreground = Brushes.Black;
            this.lblDireccion.Foreground = Brushes.Black;
            this.brSeparador.BorderBrush = Brushes.Black;
            this.brSeparador.Background = Brushes.Black;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNomContacto.Text = string.Empty;
            txtMailContact.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cboActividad.SelectedIndex = 0;
            cboTIpo.SelectedIndex = 0;

        }

        private async void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente = Ventana_Principal.listaClientes.BuscarCliente(int.Parse(txtRut.Text));
            if (cliente!=null)
            {
                txtRut.Text = cliente.Rut.ToString();
                txtRazonSocial.Text = cliente.RazonSocial;
                txtNomContacto.Text = cliente.NombreContacto;
                txtMailContact.Text = cliente.MailContacto;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono.ToString();
                cboActividad.SelectedItem = cliente.ActividadEmpresa;
                cboTIpo.SelectedItem = cliente.TipoEmpresa;

            }
            else
            {
                await this.ShowMessageAsync("Alerta:",
                        string.Format("El Cliente con Rut: {0}, NO existe!!", txtRut.Text));
            }

        }
    }
}
