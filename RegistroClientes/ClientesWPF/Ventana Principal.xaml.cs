using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para Ventana_Principal.xaml
    /// </summary>
    public partial class Ventana_Principal : MetroWindow
    {
        public Ventana_Principal()
        {
            InitializeComponent();
        }

        private void btnAdminclientes_Click(object sender, RoutedEventArgs e)
        {
            AdminClientes ac = new AdminClientes();
            ac.Show();
        }

        private void btnListarCLiente_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientesMenu listm = new ListadoClientesMenu();
            listm.Show();

        }

        private void btnListarContratos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdminContratos_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos adcon = new AdminContratos();
            adcon.Show();
        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {
            if (switchCambioBack.IsChecked==true)
            {
                ListadoClientesMenu listm = new ListadoClientesMenu();
                listm.switchCambioBack.IsChecked = true;
                this.Background = Brushes.Black;
                switchCambioBack.Foreground = Brushes.White;
                switchCambioBack.ThumbIndicatorBrush = Brushes.White;
            }
            //else 
            //{
            //    this.Background = Brushes.Red;
            //}
        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
        }

     
    }
}