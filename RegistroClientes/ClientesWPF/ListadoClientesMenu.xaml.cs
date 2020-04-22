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

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para ListadoClientesMenu.xaml
    /// </summary>
    public partial class ListadoClientesMenu : Window
    {
        private ClienteCollection clientes = new ClienteCollection();
        public ListadoClientesMenu()
        {

            InitializeComponent();
        }

        private void cboTIpo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tblClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            tblClientes.ItemsSource = clientes;
            tblClientes.Items.Refresh();
        }
    }
}
