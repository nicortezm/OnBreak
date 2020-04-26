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
    /// Lógica de interacción para ListadoContratosMenu.xaml
    /// </summary>
    public partial class ListadoContratosMenu : MetroWindow
    {
        public ListadoContratosMenu()
        {
            InitializeComponent();
        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
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
        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
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
        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Principal vp = new Ventana_Principal();   
            this.Close();
            vp.Show();
        }
    }
}
