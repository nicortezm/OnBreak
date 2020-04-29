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
namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para AdminContratos.xaml
    /// </summary>
    public partial class AdminContratos :MetroWindow
    {
        public AdminContratos()
        {
           
            InitializeComponent();
        }

        private void btnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listar = new ListadoClientes(1);
            listar.pasado += new ListadoClientes.pasar(ejecutar);
            listar.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNumContrato_TextChanged(object sender, TextChangedEventArgs e)
        {
            //String fechaContrato = DateTime.Today.ToString("dd/MM/yyyy");
           
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); Ventana_Principal vp = new Ventana_Principal();
            this.Close();
            vp.Show();
        }

        private void btnLimpiarControles_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LimpiaControles()
        {
            this.txtNumContrato.Text= string.Empty;
            this.txtFechaInicio.Text = string.Empty;
            this.txtFechaTermino.Text = string.Empty;
            this.txtCreacion.Text = string.Empty;
            this.txtTermino.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.cboActividad.SelectedIndex = 0;
            this.cboTIpo.SelectedIndex = 0;
            this.txtNombre.Text = string.Empty;
            this.txtApel.Text = string.Empty;
            this.rdbActiva.IsChecked = false;
            this.rdbInactiva.IsChecked = false;
        }

        private void btnBuscarClientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            String fechaContrato = DateTime.Now.ToString("yyyyMMddHHmm");
            this.txtNumContrato.Text = fechaContrato;
        }

        private void btnBuscarContrato_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnAztualizContrat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listco = new ListadoContratos();
            listco.Show();
            this.Close();

        }

        private void txtCreacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTermino_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFechaInicio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtFechaTermino_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboTIpo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboActividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rdbActiva_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdbInactiva_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
            this.lblActividad.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblCreacion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblDreccion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaInicio.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNombre.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblApel.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNumContrato.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTipo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblVigencia.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnLimpiarControles.BorderBrush= (Brush)bc.ConvertFrom("#2b78e4");

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            var bc = new BrushConverter();
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            this.lblActividad.Foreground = Brushes.Black;
            this.lblCreacion.Foreground = Brushes.Black;
            this.lblDreccion.Foreground = Brushes.Black;
            this.lblFechaInicio.Foreground = Brushes.Black;
            this.lblFechaTermino.Foreground = Brushes.Black;
            this.lblNombre.Foreground = Brushes.Black;
            this.lblApel.Foreground = Brushes.Black;
            this.lblNumContrato.Foreground = Brushes.Black;
            this.lblRut.Foreground = Brushes.Black;
            this.lblTermino.Foreground = Brushes.Black;
            this.lblTipo.Foreground = Brushes.Black;
            this.lblVigencia.Foreground = Brushes.Black;
            this.rdbActiva.Foreground = Brushes.Black;
            this.rdbInactiva.Foreground = Brushes.Black;
            this.rdbActiva.BorderBrush = Brushes.Black;
            this.rdbInactiva.BorderBrush = Brushes.Black;
            this.btnLimpiarControles.BorderBrush = Brushes.Black;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        public void ejecutar(Cliente cliente)
        {
            txtRut.Text = cliente.Rut.ToString();
            string nombrecontacto = cliente.NombreContacto;
            string[] listnombre = nombrecontacto.Split(' ');
            txtNombre.Text = listnombre[0];
            txtApel.Text = listnombre[1];
        }

    }
}
