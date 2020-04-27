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

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para ListadoClientesMenu.xaml
    /// </summary>
    public partial class ListadoClientesMenu : MetroWindow
    {
        
        public ListadoClientesMenu()
        {

            InitializeComponent();
            tblClientes.ItemsSource = Ventana_Principal.listaClientes;
            CargaCombo();
            
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
        }

        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
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

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
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
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboActividad_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
