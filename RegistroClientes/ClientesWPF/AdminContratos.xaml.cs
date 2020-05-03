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
    /// Lógica de interacción para AdminContratos.xaml
    /// </summary>
    public partial class AdminContratos :MetroWindow
    {
        private bool darktheme;
        public AdminContratos()
        {
            InitializeComponent();
            CargarCboTipoEvento();
        }
        public void CargarCboTipoEvento()
        {
            //this.cboTIpo.ItemsSource = "Seleccione";
            this.cboTIpo.DisplayMemberPath = "Nombre";
            this.cboTIpo.SelectedValuePath = "Id";
            this.cboTIpo.ItemsSource = Ventana_Principal.listaTipoEvento;
            this.cboTIpo.SelectedIndex = 0;

        }


        
        private void btnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            int Rut = 0;
            string Nom = string.Empty;
            Contrato xd = new Contrato();
            bool salir = false;
            foreach (var cliente in Ventana_Principal.listaClientes)
            {
                foreach (var contrato in cliente.Contrato)
                {
                    if (contrato.NumeroContrato.ToString() == txtContrato.Text)
                    {
                        xd = contrato;
                        Rut = cliente.Rut;
                        Nom = cliente.NombreContacto;
                        salir = true;
                        break;
                    }
                }
                if (salir)
                {
                    break;
                }
            }

            if (Rut != 0)
            {
                this.txtContrato.Text = xd.NumeroContrato.ToString();
                DateTime creacion = DateTime.ParseExact(xd.Creacion, "MM-dd-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime termino = DateTime.ParseExact(xd.Termino, "MM-dd-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                this.dtpCreacion.SelectedDate = creacion;
                this.dtpTermino.SelectedDate = termino;
                this.dtpFechInicio.SelectedDate = xd.FechaHoraInicio;
                this.dtpFechTermino.SelectedDate = xd.FechaHoraTermino;
                this.txtDireccion.Text = xd.Direccion;
                this.txtObservacion.Text = xd.Observaciones;
                this.txtRut.Text = Rut.ToString();
                this.cboTIpo.SelectedItem = Ventana_Principal.listaTipoEvento.NomEvento((xd.IdTipo));
                string[] nom_com = Nom.Split(' ');
                this.txtNombre.Text = nom_com[0];
                this.txtApel.Text = nom_com[1];
                if (xd.EstaVigente)
                {
                    this.rdbActiva.IsChecked = true;
                }
                else
                {
                    this.rdbInactiva.IsChecked = true;
                }   
            }
            else
            {
                this.ShowMessageAsync("Alerta:", "Contrato no existe");
            }
        }

        private void btnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listar = new ListadoClientes(1);
            if (darktheme)
            {
                listar.dark();
            }
            listar.pasado += new ListadoClientes.pasar(ejecutar);
            listar.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            TipoEvento tipev = new TipoEvento();
            Ventana_Principal vp = new Ventana_Principal();
            if (darktheme)
            {
                vp.dark();
            }
            vp.Show();
            Ventana_Principal.listaTipoEvento.Remove(tipev);
            //this.cboTIpo.Items.Clear();
            this.Close();
            
        }

        private void btnLimpiarControles_Click(object sender, RoutedEventArgs e)
        {
            LimpiaControles();
        }
        public void LimpiaControles()
        {
            this.txtContrato.Text= string.Empty;
            this.dtpCreacion.SelectedDate = DateTime.Now;
            this.dtpTermino.SelectedDate = DateTime.Now;
            this.dtpFechInicio.SelectedDate = DateTime.Now;
            this.dtpFechTermino.SelectedDate = DateTime.Now;
            this.txtDireccion.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.cboTIpo.SelectedIndex = 0;
            this.txtNombre.Text = string.Empty;
            this.txtApel.Text = string.Empty;
            this.rdbActiva.IsChecked = false;
            this.rdbInactiva.IsChecked = false;
        }

        private void btnBuscarClientes_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRut.Text))
            {
                Cliente cliente = new Cliente();
                cliente = Ventana_Principal.listaClientes.BuscarCliente(int.Parse(txtRut.Text));
                if (cliente != null)
                {
                    txtRut.Text = cliente.Rut.ToString();
                    string [] separaNomcontact= cliente.NombreContacto.Split(' ');
                    this.txtNombre.Text= separaNomcontact.ElementAt(0);
                    this.txtApel.Text = separaNomcontact.ElementAt(1);
            
                }
                else
                {
                    this.ShowMessageAsync("Alerta:",
                            string.Format("El Cliente con Rut: {0}, NO existe!!", txtRut.Text));
                }
            }
            else
            {
                this.ShowMessageAsync("Alerta:", "Debe ingresar rut para poder buscar");
            }
        }

        private void btnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtObservacion.Text) &&!string.Empty.Equals(this.txtDireccion.Text)
                //&& !String.IsNullOrWhiteSpace(this.txtFechaInicio.Text) && !String.IsNullOrWhiteSpace(this.txtFechaTermino.Text)
                 && this.cboTIpo.SelectedIndex!=0 && this.rdbActiva.IsChecked==true && !String.IsNullOrWhiteSpace(this.txtRut.Text))
            {
                
                bool vigenteIs = EstadoVigencia();
                bool seAgrego = false;
                Contrato contrato = new Contrato
                {
                    NumeroContrato = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm")),
                    Creacion = this.dtpCreacion.SelectedDate.Value.ToString("MM-dd-yyyy"),
                    Termino = this.dtpTermino.SelectedDate.Value.ToString("MM-dd-yyyy"),
                    IdTipo = int.Parse(this.cboTIpo.SelectedValue.ToString()),
                    EstaVigente = vigenteIs,
                    Observaciones = this.txtObservacion.Text,
                    Direccion = this.txtDireccion.Text,
                    FechaHoraInicio = this.dtpFechInicio.SelectedDate.Value,
                    FechaHoraTermino = this.dtpFechTermino.SelectedDate.Value

                };
                foreach (var cliente in Ventana_Principal.listaClientes)
                {
                    if (txtRut.Text == cliente.Rut.ToString())
                    {
                        cliente.Contrato.Add(contrato);
                        seAgrego = true;
                        break;
                    }
                }
                if (!seAgrego)
                {
                    this.ShowMessageAsync("Alerta:", "Error al agregar contrato");
                }
                else
                {
                    this.ShowMessageAsync("Confirmacion:",
                        string.Format("El COntrato con numero Contrato: {0}, fué agregado con exito!!", contrato.NumeroContrato.ToString()));
                }
               
                
               
            }
            else
            {
                 this.ShowMessageAsync("Alerta:", "Debe Completar todos los datos");
            }
            //String fechaContrato = DateTime.Now.ToString("yyyyMMddHHmm");
            //int fechaContrato = int.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
            //this.txtNumContrato.Text = fechaContrato;
        }

        public bool EstadoVigencia()
        {
            bool vigente = false;
            if (this.rdbActiva.IsChecked == true)
            {
                vigente = true;
            }
            else if (this.rdbInactiva.IsChecked == true)
            {
                vigente = false;

            }
            return vigente;
        }



        private void btnAztualizContrat_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtObservacion.Text) && !string.Empty.Equals(this.txtDireccion.Text)
                 //&& !String.IsNullOrWhiteSpace(this.txtFechaInicio.Text) && !String.IsNullOrWhiteSpace(this.txtFechaTermino.Text)
                 && this.cboTIpo.SelectedIndex != 0 && this.rdbActiva.IsChecked == true && !String.IsNullOrWhiteSpace(this.txtRut.Text))
            {
                bool seAgrego = false;
                foreach (var cliente in Ventana_Principal.listaClientes)
                {
                    foreach (var contrato in cliente.Contrato)
                    {
                        if (contrato.NumeroContrato.ToString() == txtContrato.Text)
                        {
                            bool vigenteIs = EstadoVigencia();

                            Contrato xd = new Contrato
                            {
                                NumeroContrato = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm")),
                                Creacion = this.dtpCreacion.SelectedDate.Value.ToString("MM/dd/yyyy"),
                                Termino = this.dtpTermino.SelectedDate.Value.ToString("MM/dd/yyyy"),
                                IdTipo = int.Parse(this.cboTIpo.SelectedValue.ToString()),
                                EstaVigente = vigenteIs,
                                Observaciones = this.txtObservacion.Text,
                                Direccion = this.txtDireccion.Text,
                                FechaHoraInicio = this.dtpFechInicio.SelectedDate.Value,
                                FechaHoraTermino = this.dtpFechTermino.SelectedDate.Value

                            };

                            cliente.Contrato[cliente.Contrato.FindIndex(ind => ind.NumeroContrato == long.Parse(txtContrato.Text))] = xd;
                            seAgrego = true;
                            break;
                        }
                    }
                    if (seAgrego)
                    {
                        this.ShowMessageAsync("Confirmacion:",
                        string.Format("El Contrato con numero Contrato: {0}, fué modificado con exito!!", txtContrato.Text));
                        break;
                    }

                }
            }
            else
            {
                this.ShowMessageAsync("Alerta:", "Debe Completar todos los datos");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listar = new ListadoContratos(1);
            if (darktheme)
            {
                listar.dark();
            }
            listar.pasado += new ListadoContratos.pasar(ejecutar_contrato);
            listar.Show();

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {

            dark();
        }
        public void dark()
        {
            var bc = new BrushConverter();
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
           
            this.lblCreacion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblDreccion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaInicio.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNombre.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblApel.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTipo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblVigencia.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblObservacion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnLimpiarControles.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            darktheme = true;
            switchCambioBack.IsChecked = true;

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            light();
        }
        public void light()
        {
            var bc = new BrushConverter();
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            this.lblCreacion.Foreground = Brushes.Black;
            this.lblDreccion.Foreground = Brushes.Black;
            this.lblFechaInicio.Foreground = Brushes.Black;
            this.lblFechaTermino.Foreground = Brushes.Black;
            this.lblNombre.Foreground = Brushes.Black;
            this.lblApel.Foreground = Brushes.Black;
            this.lblRut.Foreground = Brushes.Black;
            this.lblTermino.Foreground = Brushes.Black;
            this.lblTipo.Foreground = Brushes.Black;
            this.lblVigencia.Foreground = Brushes.Black;
            this.lblObservacion.Foreground = Brushes.Black;
            this.rdbActiva.Foreground = Brushes.Black;
            this.rdbInactiva.Foreground = Brushes.Black;
            this.rdbActiva.BorderBrush = Brushes.Black;
            this.rdbInactiva.BorderBrush = Brushes.Black;
            this.btnLimpiarControles.BorderBrush = Brushes.Black;
            darktheme = false;
        }

        public void ejecutar(Cliente cliente,bool seleccionado,bool dark)
        {
            if (seleccionado)
            {
                txtRut.Text = cliente.Rut.ToString();
                string nombrecontacto = cliente.NombreContacto;
                string[] listnombre = nombrecontacto.Split(' ');
                txtNombre.Text = listnombre[0];
                txtApel.Text = listnombre[1];
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
        public void ejecutar_contrato(Contrato contrato,bool seleccionado, bool dark)
        {
            if (seleccionado)
            {
                txtDireccion.Text = contrato.Direccion;
                string[] aux = Ventana_Principal.listaClientes.EncontrarNombre(contrato.NumeroContrato).Split(' ');
                txtNombre.Text = aux[0];
                txtApel.Text = aux[1];
                DateTime creacion = DateTime.ParseExact(contrato.Creacion, "MM-dd-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime termino = DateTime.ParseExact(contrato.Termino, "MM-dd-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                this.dtpCreacion.SelectedDate = creacion;
                this.dtpTermino.SelectedDate = termino;
                this.dtpFechInicio.SelectedDate = contrato.FechaHoraInicio;
                this.dtpFechTermino.SelectedDate = contrato.FechaHoraTermino;
                this.txtDireccion.Text = contrato.Direccion;
                this.txtObservacion.Text = contrato.Observaciones;
                this.txtRut.Text = Ventana_Principal.listaClientes.EncontrarRut(contrato.NumeroContrato);
                this.cboTIpo.SelectedItem = Ventana_Principal.listaTipoEvento.NomEvento((contrato.IdTipo));
                if (contrato.EstaVigente)
                {
                    this.rdbActiva.IsChecked = true;
                }
                else
                {
                    this.rdbInactiva.IsChecked = true;
                }

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

        private void btnnumcontrato_Click(object sender, RoutedEventArgs e)
        {
            txtContrato.IsEnabled = true;
        }
    }
}
