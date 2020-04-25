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
        }

      

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtMailContact_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboActividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRazonSocial_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtMailContact_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void cboTIpo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {

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
            listar.Show();
        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            //Ventana_Principal vp = new Ventana_Principal();
            //vp.Show();
            this.Close();

        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            
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
    }
}
