using BibliotecaClientes;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using  ClientesWPF;
namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para Ventana_Principal.xaml
    /// </summary>
    /// 
    
    public partial class Ventana_Principal : MetroWindow
    {
        private bool darktheme;
        public static ClienteCollection listaClientes = new ClienteCollection();
        public static ContratoCollection listaContratos = new ContratoCollection();
        public static TipoEventoCollection listaTipoEvento = new TipoEventoCollection();

        public Ventana_Principal()
        {
            
            InitializeComponent();
            this.switchCambioBack.ToolTip = "Switch para cambiar Contraste";

            //llenarClientes();
        }

        private void btnAdminclientes_Click(object sender, RoutedEventArgs e)
        {

            AdminClientes ac = new AdminClientes();
            if (darktheme)
            {
                ac.dark();
            }
            ac.Show();
            this.Close();
        }

        private void btnListarCLiente_Click(object sender, RoutedEventArgs e)
        {

            ListadoClientes listm = new ListadoClientes();
            if (darktheme)
            {
                listm.dark();
            }
            listm.Show();
            this.Close();

        }


        private void btnListarContratos_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listco = new ListadoContratos();
            if (darktheme)
            {
                listco.dark();
            }
            listco.Show();
            this.Close();
        }

        private void btnAdminContratos_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos adcon = new AdminContratos();
            if (darktheme)
            {
                adcon.dark();
            }
            adcon.Show();
            this.Close();
        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {

            dark();

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            
            light();
            


        }
        public void dark()
        {
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
            switchCambioBack.IsChecked = true;
            darktheme = true;
        }
        public void light()
        {
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            darktheme = false;
        }

    }
}