using BibliotecaClientes;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data;

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : MetroWindow
    {
        //creo delegado pa enviar datos
        public delegate void pasar(Cliente dato, bool seleccionado, bool dark);
        public event pasar pasado;
        private bool darktheme;
        public ListadoClientes()
        {

            InitializeComponent();
            this.switchCambioBack.ToolTip = "Switch para cambiar Contraste";
            //dgClientes.ItemsSource = Ventana_Principal.listaClientes;
            CargaCombo();
            Init();
            btnSelectCliente.Visibility = Visibility.Collapsed;
            btnAtras.Visibility = Visibility.Collapsed;
        }
        public ListadoClientes(int number)

        {
            InitializeComponent();
            this.switchCambioBack.ToolTip = "Switch para cambiar Contraste";
            //dgClientes.ItemsSource = Ventana_Principal.listaClientes;
            CargaCombo();
            Init();
            btnSelectCliente.Visibility = Visibility.Visible;
            btnVentanaPrincipal.Visibility = Visibility.Collapsed;
            btnAtras.Visibility = Visibility.Visible;

        }
        private void Init()
        {
            dgClientes.Items.Clear();
            txtRut.Text = string.Empty;
            foreach (var cliente in Ventana_Principal.listaClientes)
            {
                dgClientes.Items.Add(cliente);
            }
        }

        private void CargaCombo()
        {
            cboActividad.ItemsSource = Enum.GetValues(typeof(ActividadEmpresa));
            cboActividad.SelectedIndex = 0;
            cboTIpo.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            cboTIpo.SelectedIndex = 0;
        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            dgClientes.Items.Clear();
            if (string.IsNullOrWhiteSpace(txtRut.Text) && cboTIpo.SelectedIndex == 0 && cboActividad.SelectedIndex == 0)
            {
                this.ShowMessageAsync("Alerta:", "Porfavor edite los filtros  para buscar cientes");
                Init();
            }
            else
            {
                foreach (var cliente in Ventana_Principal.listaClientes)
                {
                    if (!string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex == 0 && cboTIpo.SelectedIndex == 0) // 1
                    {
                        if (txtRut.Text == cliente.Rut.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex == 0 && cboTIpo.SelectedIndex != 0) //2
                    {
                        if (txtRut.Text == cliente.Rut.ToString() && cboTIpo.SelectedItem.ToString() == cliente.TipoEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex != 0 && cboTIpo.SelectedIndex == 0)// 3
                    {
                        if (txtRut.Text == cliente.Rut.ToString() && cboActividad.SelectedItem.ToString() == cliente.ActividadEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex != 0 && cboTIpo.SelectedIndex != 0) // 4
                    {
                        if (txtRut.Text == cliente.Rut.ToString() && cboActividad.SelectedItem.ToString() == cliente.ActividadEmpresa.ToString() && cboTIpo.SelectedItem.ToString() == cliente.TipoEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex == 0 && cboTIpo.SelectedIndex != 0) //6
                    {
                        if (cboTIpo.SelectedItem.ToString() == cliente.TipoEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex != 0 && cboTIpo.SelectedIndex == 0) //7 
                    {
                        if (cboActividad.SelectedItem.ToString() == cliente.ActividadEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(txtRut.Text) && cboActividad.SelectedIndex != 0 && cboTIpo.SelectedIndex != 0) //8
                    {
                        if (cboActividad.SelectedItem.ToString() == cliente.ActividadEmpresa.ToString() && cboTIpo.SelectedItem.ToString() == cliente.TipoEmpresa.ToString())
                        {
                            dgClientes.Items.Add(cliente);
                        }
                    }
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
            this.btnLimpiar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnBuscar.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.brCuadroDataGrid.BorderBrush = Brushes.White;
            this.brCuadroDataGrid.Background = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblTIpo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblActividad.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblTitulo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            switchCambioBack.IsChecked = true;
            darktheme = true;

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
            this.btnLimpiar.BorderBrush = Brushes.Black;
            this.btnBuscar.BorderBrush = Brushes.Black;
            this.brCuadroDataGrid.Background = Brushes.White;
            this.brCuadroDataGrid.BorderBrush = Brushes.Black;
            lblTIpo.Foreground = Brushes.Black;
            lblActividad.Foreground = Brushes.Black;
            lblTitulo.Foreground = Brushes.Black;
            darktheme = false;
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Init();
            txtRut.Text = string.Empty;
            cboActividad.SelectedIndex = 0;
            cboTIpo.SelectedIndex = 0;
        }


        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Principal vp = new Ventana_Principal();
            if (darktheme)
            {
                vp.dark();
            }
            vp.Show();
            this.Close();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();
            pasado(cli, false, darktheme);
            this.Close();

        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClientes.Items.Count != 0)
            {
                DataGrid gd = (DataGrid)sender;
                dynamic rowSelected = gd.SelectedItem;
                txtAux.Text = rowSelected.Rut + string.Empty;
            }




        }

        private async void btnSelectCliente_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAux.Text))
            {

                pasado(Ventana_Principal.listaClientes.BuscarCliente(int.Parse(txtAux.Text)), true, darktheme);
                this.Close();
            }
            else
            {
                await this.ShowMessageAsync("Alerta:", "Debe Seleccionar un Cliente");
            }


        }

    }
}
