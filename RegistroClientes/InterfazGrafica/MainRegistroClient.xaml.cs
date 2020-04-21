using System.Windows;
using System.Windows.Controls;
using BibliotecaClientes;


namespace InterfazGrafica
{
    /// <summary>
    /// Lógica de interacción para MainRegistroClient.xaml
    /// </summary>
    public partial class MainRegistroClient : Window
    {
        public MainRegistroClient()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void cboTIpo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboTIpo.Items.Add("SPA");
            cboTIpo.Items.Add("EIRL");
            cboTIpo.Items.Add("Limitada");
            cboTIpo.Items.Add("Sociedad Anonima");
        }

        private void cboActividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboActividad.Items.Add("Agropecuaria");
            cboActividad.Items.Add("Mineria");
            cboActividad.Items.Add("Manufactura");
            cboActividad.Items.Add("Comercio");
            cboActividad.Items.Add("Hoteleria");
            cboActividad.Items.Add("Alimentos");
            cboActividad.Items.Add("Transportes");
        }


    }
}
