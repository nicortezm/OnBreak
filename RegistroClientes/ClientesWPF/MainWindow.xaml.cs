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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BibliotecaClientes;
using MahApps.Metro.Controls;

namespace ClientesWPF
{
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private ClienteCollection clientes = new ClienteCollection();
        //Cliente cli = new Cliente();
        //private List<Cliente> clientList = new List<Cliente>();

        public MainWindow()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            this.cboActividad.ItemsSource = Enum.GetValues(typeof (ActividadEmpresa));
            this.cboTIpo.ItemsSource = Enum.GetValues(typeof(TipoEmpresa));
            this.cboActividad.SelectedIndex = 0;
            this.cboTIpo.SelectedIndex = 0;

        }

        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            //his.Consultar();
            if (this.txtRut.Text != string.Empty)
            {
                if (this.clientes.Existe(int.Parse(this.txtRut.Text)))
                {
                    Cliente client = clientes.BuscarCliente(int.Parse(this.txtRut.Text));
                    this.txtTelefono.Text = client.Telefono.ToString();
                    this.txtDireccion.Text = client.Direccion;
                    this.txtRazonSocial.Text = client.RazonSocial;
                    this.cboActividad.SelectedValue = client.Actividad;
                    this.cboTIpo.SelectedValue = client.Tipo;
                }
                else
                {
                    MessageBox.Show("CLIENTE NO EXISTE!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("NO DEJE EL CAMPO VACIO DE RUT!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cboTIpo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
        }

        private void cboActividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (!clientes.Existe(int.Parse(this.txtRut.Text)))
            {
                Cliente cli = new Cliente()
                {
                    Rut = int.Parse(this.txtRut.Text),
                    Telefono = int.Parse(this.txtTelefono.Text),
                    Direccion = this.txtDireccion.Text,
                    RazonSocial = this.txtRazonSocial.Text,
                    Actividad = (ActividadEmpresa)this.cboActividad.SelectedValue,
                    Tipo = (TipoEmpresa)this.cboTIpo.SelectedValue
                };


                clientes.Add(cli);
                Limpiar();
                MessageBox.Show("CLIENTE AGREGADO CON EXITO", "Informacion ", MessageBoxButton.OK, MessageBoxImage.Information);
                this.MostrarClientes();
            }
            else
            {
                MessageBox.Show("CLIENTE YA EXISTE", "ERROR ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void MostrarClientes()
        {
            dgTableCliente.ItemsSource = clientes;
            dgTableCliente.Items.Refresh();
        }
      

        public void Limpiar()
        {
            this.txtRut.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtRazonSocial.Text = string.Empty;
            this.cboActividad.SelectedIndex = 0;
            this.cboTIpo.SelectedIndex = 0;
        }
        private void dgTableCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
      

        public void EliminarClient()
        {
            //try
            //{
            //    Cliente cl = this.clientList.First(c => c.Rut == this.txtRut.Text);
            //    this.clientList.Remove(cl);
            //    this.MostrarClientes();
            //    this.Limpiar();
      
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Cliente No encontrado");
            //}
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (clientes.Existe(int.Parse(this.txtRut.Text)))

            {
                Cliente cli = new Cliente()
                {
                    Rut = int.Parse(this.txtRut.Text),
                    Telefono = int.Parse(this.txtTelefono.Text),
                    Direccion = this.txtDireccion.Text,
                    RazonSocial = this.txtRazonSocial.Text,
                    Actividad = (ActividadEmpresa)this.cboActividad.SelectedValue,
                    Tipo = (TipoEmpresa)this.cboTIpo.SelectedValue
                };
                
                this.Limpiar();
                MessageBox.Show("MODIFICADO CON EXITO!!!");
                this.MostrarClientes();

            }
            else
            {
                //ALERTA65
                MessageBox.Show("CAMPO RUT ESTA VACIO.....INGRESE  PORFAVOR!!!!");
            }


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (clientes.Existe(int.Parse(this.txtRut.Text)))
            {
                Cliente client = clientes.BuscarCliente(int.Parse(this.txtRut.Text));
                MessageBoxResult result = MessageBox.Show("Seguro que desea Eliminar??","Confirmacion",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result==MessageBoxResult.Yes)
                {
                    clientes.Remove(client);
                    MostrarClientes();
                    MessageBox.Show("CLIENTE Eliminado CON EXITO", "Informacion ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
