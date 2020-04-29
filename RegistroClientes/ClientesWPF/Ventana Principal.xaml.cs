﻿using BibliotecaClientes;
using MahApps.Metro;
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

        public static ClienteCollection listaClientes = new ClienteCollection();
        public static ContratoCollection listaContratos = new ContratoCollection();
        public static TipoEventoCollection listaTipoEvento = new TipoEventoCollection();
        //public delegate void pasarEstado(bool estado); 
        //public event pasarEstado enviado;
        public Ventana_Principal()
        {
           
           

            InitializeComponent();
            //llenarClientes();
        }

        private void btnAdminclientes_Click(object sender, RoutedEventArgs e)
        {
            
            AdminClientes ac = new AdminClientes();
            ac.Show();
            this.Close();
        }

        private void btnListarCLiente_Click(object sender, RoutedEventArgs e)
        {

            ListadoClientes listm = new ListadoClientes();
            listm.Show();
            this.Close();

        }
        /*
        private void llenarClientes()
        {
            Cliente cliente = new Cliente()
            {
                Rut = 123,
                RazonSocial = "xd",
                NombreContacto = "xd",
                MailContacto = "xd",
                Telefono = 123
            };
            listaClientes.Add(cliente);
        }*/

        private void btnListarContratos_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listco = new ListadoContratos();
            listco.Show();
            this.Close();
        }

        private void btnAdminContratos_Click(object sender, RoutedEventArgs e)
        {
            AdminContratos adcon = new AdminContratos();
            adcon.Show();
            this.Close();
        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {
            //ThemeManager.AddAppTheme("CustomDark", new Uri("pack://application:,,,/CustomDark.xaml"));
            //enviado(true);
            AdminClientes ad = new AdminClientes();
        
            this.Background = Brushes.Black;
            //switchCambioBack.Foreground = Brushes.White;
            //switchCambioBack.ThumbIndicatorBrush = Brushes.White;

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            
            AdminClientes adm = new AdminClientes();

           
            this.Background = Brushes.White;
            //switchCambioBack.Foreground = Brushes.Black;
            //switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
        }
       
    }
}