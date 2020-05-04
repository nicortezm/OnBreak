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
    /// Lógica de interacción para ListadoContratosMenu.xaml
    /// </summary>
    public partial class ListadoContratos : MetroWindow
    {
        private bool darktheme;
        public delegate void pasar(Contrato dato, bool seleccionado, bool dark);
        public event pasar pasado;
        public ListadoContratos()
        {
            InitializeComponent();
            if (dgContratos.Items.Count == 0)
            {
                this.ShowMessageAsync("Alerta:", "No hay contratos registrados");
            }
            CargarCboTipoEvento();
            Init();
            btnSelectContrato.Visibility = Visibility.Collapsed;
            btnAtras.Visibility = Visibility.Collapsed;
        }
        public ListadoContratos(int number)
        {
            InitializeComponent();
            if (dgContratos.Items.Count == 0)
            {
                this.ShowMessageAsync("Alerta:", "No hay contratos registrados");
            }
            Init();
            CargarCboTipoEvento();
            btnSelectContrato.Visibility = Visibility.Visible;
            btnVentanaPrincipal.Visibility = Visibility.Collapsed;
            btnAtras.Visibility = Visibility.Visible;
        }
        public void CargarCboTipoEvento()
        {
            foreach (var evento in Ventana_Principal.listaTipoEvento)
            {
                cboTIpo.Items.Add(evento.Nombre);
            }
            cboTIpo.SelectedIndex = 0;
        }

        private void Init()
        {
            dgContratos.Items.Clear();
            foreach (var cliente in Ventana_Principal.listaClientes)
            {
                foreach (var contrato in cliente.Contrato)
                {
                    dgContratos.Items.Add(contrato);
                }
            }

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
            this.brCuadroDataGrid.Background = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnLimpiar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnBuscar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTitulo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNroContrato.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTIpo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            switchCambioBack.IsChecked = true;
            darktheme = true;
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
            this.brCuadroDataGrid.Background = Brushes.White;
            this.btnLimpiar.BorderBrush = Brushes.Black;
            this.btnBuscar.BorderBrush = Brushes.Black;
            this.lblTitulo.Foreground = Brushes.Black;
            this.lblNroContrato.Foreground = Brushes.Black;
            this.lblRut.Foreground = Brushes.Black;
            this.lblTIpo.Foreground = Brushes.Black;
            darktheme = false;
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

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Contrato con = new Contrato();
            pasado(con, false, darktheme);
            this.Close();
        }

        private void dgContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgContratos.Items.Count != 0)
            {
                DataGrid gd = (DataGrid)sender;
                dynamic rowSelected = gd.SelectedItem;
                txtAux.Text = rowSelected.NumeroContrato + string.Empty;
            }

        }

        private void btnSelectContrato_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAux.Text))
            {

                pasado(Ventana_Principal.listaClientes.BuscarContrato(long.Parse(txtAux.Text)), true, darktheme);
                this.Close();
            }
            else
            {
                this.ShowMessageAsync("Alerta:", "Debe Seleccionar un contrato");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgContratos.Items.Clear();
            if (string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex == 0 && string.IsNullOrWhiteSpace(txtRut.Text))
            {
                this.ShowMessageAsync("Alerta:", "Cambie los filtros para poder buscar");
                Init();
            }
            else
            {
                foreach (var cliente in Ventana_Principal.listaClientes)
                {
                    if (!string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex != 0 && !string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (contrato.NumeroContrato.ToString() == txtNumContrato.Text && cboTIpo.SelectedItem.ToString() == Ventana_Principal.listaTipoEvento.NomEvento(contrato.IdTipo) && cliente.Rut.ToString() == txtRut.Text)
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex != 0 && string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (contrato.NumeroContrato.ToString() == txtNumContrato.Text && cboTIpo.SelectedItem.ToString() == Ventana_Principal.listaTipoEvento.NomEvento(contrato.IdTipo))
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex == 0 && !string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (contrato.NumeroContrato.ToString() == txtNumContrato.Text && cliente.Rut.ToString() == txtRut.Text)
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex == 0 && string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (contrato.NumeroContrato.ToString() == txtNumContrato.Text)
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex != 0 && !string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (cboTIpo.SelectedItem.ToString() == Ventana_Principal.listaTipoEvento.NomEvento(contrato.IdTipo) && cliente.Rut.ToString() == txtRut.Text)
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex != 0 && string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (cboTIpo.SelectedItem.ToString() == Ventana_Principal.listaTipoEvento.NomEvento(contrato.IdTipo))
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtNumContrato.Text) && cboTIpo.SelectedIndex == 0 && !string.IsNullOrWhiteSpace(txtRut.Text))
                    {
                        foreach (var contrato in cliente.Contrato)
                        {
                            if (cliente.Rut.ToString() == txtRut.Text)
                            {
                                dgContratos.Items.Add(contrato);
                            }
                        }
                    }
                }
                if (dgContratos.Items.Count == 0)
                {
                    this.ShowMessageAsync("Alerta:", "No hay contratos que cumplan con los filtros");
                    Init();
                    txtRut.Text = string.Empty;
                    cboTIpo.SelectedIndex = 0;
                    txtNumContrato.Text = string.Empty;

                }
            }
           

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Init();
            txtRut.Text = string.Empty;
            cboTIpo.SelectedIndex = 0;
            txtNumContrato.Text = string.Empty;
        }
    }
}
