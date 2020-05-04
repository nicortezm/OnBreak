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
using MahApps.Metro.Behaviours;
using ClientesWPF;
using MahApps.Metro;
using System.Text.RegularExpressions;

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para AdminClientes.xaml
    /// </summary>
    
    public partial class AdminClientes : MetroWindow
    {
        public bool darktheme;
        public AdminClientes()
        {
            
            InitializeComponent();
            this.switchCambioBack.ToolTip = "Switch para cambiar Contraste";
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
            

            if (!string.IsNullOrWhiteSpace(txtRut.Text) && !string.IsNullOrWhiteSpace(txtNomContacto.Text) && !string.IsNullOrWhiteSpace(txtRazonSocial.Text) && !string.IsNullOrWhiteSpace(txtMailContact.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text) && cboActividad.SelectedIndex!=0 && cboTIpo.SelectedIndex!=0 )
            {
                string[] nomcom = txtNomContacto.Text.Split(' ');
                if (nomcom.Length != 2)
                {
                    await this.ShowMessageAsync("Alerta:", "Debe respetar el formato 'Nombre Apellido'");
                }
                else
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

                
            }
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe Completar todos los datos");
            }

        }

        private async void btnAztualizClient_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRut.Text) && !string.IsNullOrWhiteSpace(txtNomContacto.Text) && !string.IsNullOrWhiteSpace(txtRazonSocial.Text) && !string.IsNullOrWhiteSpace(txtMailContact.Text)
                && !string.IsNullOrWhiteSpace(txtTelefono.Text) && cboActividad.SelectedIndex != 0 && cboTIpo.SelectedIndex != 0)
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

                if (Ventana_Principal.listaClientes.ModificarCliente(cliente))
                {
                    await this.ShowMessageAsync("Confirmacion:",
                        string.Format("El Cliente con Rut: {0}, fue modificado con exito!!", txtRut.Text));
                }
                else
                {
                    await this.ShowMessageAsync("Alerta:",
                        string.Format("El Cliente con Rut: {0}, No existe!!", txtRut.Text));
                }
            }
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe Completar todos los datos");
            }

        }

        private async void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRut.Text))
            {
                if (Ventana_Principal.listaClientes.EliminarCliente(int.Parse(txtRut.Text)))
                {
                    await this.ShowMessageAsync("Confirmacion:",
                        string.Format("El Cliente con Rut: {0}, fue eliminado con exito!!", txtRut.Text));
                }
                else
                {
                    await this.ShowMessageAsync("Alerta:",
                        string.Format("El Cliente con Rut: {0}, no existe o no se pudo eliminar!!", txtRut.Text));
                }
                
            }
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe ingresar rut valido para eliminar");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listar = new ListadoClientes(1);
            if (darktheme)
            {
                listar.dark();
            }
            listar.pasado += new ListadoClientes.pasar(ejecutar);
            listar.Show();
        }
        public void ejecutar(Cliente cliente,bool seleccionado,bool dark)
        {
            if (seleccionado)
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
            if (dark)
            {
                this.dark();
            }
            else
            {
                this.light();
                switchCambioBack.IsChecked = false;
            }

        }


        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Principal vp = new Ventana_Principal();
            if (darktheme)
            {
                vp.dark();
            }
            this.Close();
            vp.Show();

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {

            dark();


        }
        public void dark()
        {
            //variable que convierte que cambia los parametros de escojer color..
            var bc = new BrushConverter();
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
            this.btnLimpiar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");


            this.btnLimpiar.Foreground = Brushes.Black;
            this.lblTitulo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTIpo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRazonSocial.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblMailContact.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNomContact.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblctividad.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTelefon.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblDireccion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            darktheme = true;
            switchCambioBack.IsChecked = true;

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            light();
            
        }
        public void light()
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
            //this.lblDireccion.Foreground = Brushes.Black;
            darktheme = false;
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
            if (!string.IsNullOrWhiteSpace(txtRut.Text))
            {
                Cliente cliente = new Cliente();
                cliente = Ventana_Principal.listaClientes.BuscarCliente(int.Parse(txtRut.Text));
                if (cliente != null)
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
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe ingresar rut para poder buscar");
            }

        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
