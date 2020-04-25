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
    /// Lógica de interacción para ListadoClientesAuxiliar.xaml
    /// </summary>
    public partial class ListadoClientesAuxiliar : MetroWindow
    {
        public ListadoClientesAuxiliar()
        {
            InitializeComponent();
        }

        private void txtRut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboActividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tblClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
            this.brCuadroDataGrid.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.brCuadroDataGrid.Background = (Brush)bc.ConvertFrom("#2b78e4");
    
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblTIpo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblctividad.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            lblTitulo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");



        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            var bc =new  BrushConverter();
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            this.brCuadroDataGrid.Background = Brushes.White;
            this.brCuadroDataGrid.BorderBrush = Brushes.Black;
            lblTIpo.Foreground = Brushes.Black;
            lblctividad.Foreground = Brushes.Black;
            lblTitulo.Foreground = Brushes.Black;


        }

        private void btnSelectCliente_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
