﻿using System;
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
using BibliotecaClientes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ClientesWPF
{
    /// <summary>
    /// Lógica de interacción para AdminContratos.xaml
    /// </summary>
    public partial class AdminContratos :MetroWindow
    {
        private bool darktheme;
        public AdminContratos()
        {
           
            InitializeComponent();
        }

        private void btnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ListadoClientes listar = new ListadoClientes(1);
            if (darktheme)
            {
                listar.dark();
            }
            listar.pasado += new ListadoClientes.pasar(ejecutar);
            listar.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNumContrato_TextChanged(object sender, TextChangedEventArgs e)
        {
            //String fechaContrato = DateTime.Today.ToString("dd/MM/yyyy");
           
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentanaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            Ventana_Principal vp = new Ventana_Principal();
            if (darktheme)
            {
                vp.dark();
            }
            vp.Show();
            this.Close();
            
        }

        private void btnLimpiarControles_Click(object sender, RoutedEventArgs e)
        {
            LimpiaControles();
        }
        public void LimpiaControles()
        {
            //this.txtNumContrato.Text= string.Empty;
            this.txtFechaInicio.Text = string.Empty;
            this.txtFechaTermino.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtRut.Text = string.Empty;
            this.cboTIpo.SelectedIndex = 0;
            this.txtNombre.Text = string.Empty;
            this.txtApel.Text = string.Empty;
            this.rdbActiva.IsChecked = false;
            this.rdbInactiva.IsChecked = false;
        }

        private void btnBuscarClientes_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRut.Text))
            {
                Cliente cliente = new Cliente();
                cliente = Ventana_Principal.listaClientes.BuscarCliente(int.Parse(txtRut.Text));
                if (cliente != null)
                {
                    txtRut.Text = cliente.Rut.ToString();
                    string [] separaNomcontact= cliente.NombreContacto.Split(' ');
                    this.txtNombre.Text= separaNomcontact.ElementAt(0);
                    this.txtApel.Text = separaNomcontact.ElementAt(1);
            
                }
                else
                {
                    //await this.ShowMessageAsync("Alerta:",
                    //        string.Format("El Cliente con Rut: {0}, NO existe!!", txtRut.Text));
                }
            }
            else
            {
                //await this.ShowMessageAsync("Alerta:", "Debe ingresar rut para poder buscar");
            }
        }

        private void btnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            bool vigenteIs = EstadoVigencia();
            Contrato contrato = new Contrato
            {
                NumeroContrato = int.Parse(DateTime.Now.ToString("yyyyMMddHHmm")),
                Creacion = this.dtpCreacion.SelectedDate.ToString(),
                Termino = this.dtpCreacion.SelectedDate.ToString(),
               //Termino =this.dtpCreacion.SelectedDate.ToString(),
                EstaVigente = vigenteIs,
                Observaciones=this.txtObservacion.Text,
                Direccion=this.txtDireccion.Text,
                FechaHoraInicio= DateTime.Now.ToString("yyyyMMddHHmm"),
                FechaHoraTermino = "------------"



            };
            //String fechaContrato = DateTime.Now.ToString("yyyyMMddHHmm");
            //int fechaContrato = int.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
            //this.txtNumContrato.Text = fechaContrato;
        }

        public bool EstadoVigencia()
        {
            bool vigente = false;
            if (this.rdbActiva.IsChecked == true)
            {
                vigente = true;
            }
            else if (this.rdbInactiva.IsChecked == true)
            {
                vigente = false;

            }
            return vigente;
        }

        private void btnBuscarContrato_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnAztualizContrat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos listar = new ListadoContratos(1);
            if (darktheme)
            {
                listar.dark();
            }
            listar.pasado += new ListadoContratos.pasar(ejecutar_contrato);
            listar.Show();

        }

        private void switchCambioBack_Checked(object sender, RoutedEventArgs e)
        {

            dark();
        }
        public void dark()
        {
            var bc = new BrushConverter();
            this.Background = Brushes.Black;
            switchCambioBack.Foreground = Brushes.White;
            switchCambioBack.ThumbIndicatorBrush = Brushes.White;
           
            this.lblCreacion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblDreccion.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaInicio.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblFechaTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblNombre.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblApel.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblRut.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTermino.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblTipo.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.lblVigencia.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.Foreground = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbActiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.rdbInactiva.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            this.btnLimpiarControles.BorderBrush = (Brush)bc.ConvertFrom("#2b78e4");
            darktheme = true;
            switchCambioBack.IsChecked = true;

        }

        private void switchCambioBack_IsCheckedChanged(object sender, EventArgs e)
        {
            light();
        }
        public void light()
        {
            var bc = new BrushConverter();
            this.Background = Brushes.White;
            switchCambioBack.Foreground = Brushes.Black;
            switchCambioBack.ThumbIndicatorBrush = Brushes.Black;
            this.lblCreacion.Foreground = Brushes.Black;
            this.lblDreccion.Foreground = Brushes.Black;
            this.lblFechaInicio.Foreground = Brushes.Black;
            this.lblFechaTermino.Foreground = Brushes.Black;
            this.lblNombre.Foreground = Brushes.Black;
            this.lblApel.Foreground = Brushes.Black;
            this.lblRut.Foreground = Brushes.Black;
            this.lblTermino.Foreground = Brushes.Black;
            this.lblTipo.Foreground = Brushes.Black;
            this.lblVigencia.Foreground = Brushes.Black;
            this.rdbActiva.Foreground = Brushes.Black;
            this.rdbInactiva.Foreground = Brushes.Black;
            this.rdbActiva.BorderBrush = Brushes.Black;
            this.rdbInactiva.BorderBrush = Brushes.Black;
            this.btnLimpiarControles.BorderBrush = Brushes.Black;
            darktheme = false;
        }

        public void ejecutar(Cliente cliente,bool seleccionado,bool dark)
        {
            if (seleccionado)
            {
                txtRut.Text = cliente.Rut.ToString();
                string nombrecontacto = cliente.NombreContacto;
                string[] listnombre = nombrecontacto.Split(' ');
                txtNombre.Text = listnombre[0];
                txtApel.Text = listnombre[1];
            }
            if (dark)
            {
                this.dark();
            }
            else
            {
                this.light();
                switchCambioBack.IsChecked = false;
            }

        }
        public void ejecutar_contrato(Contrato contrato,bool seleccionado, bool dark)
        {
            if (seleccionado)
            {

            }
            if (dark)
            {
                this.dark();
            }
            else
            {
                this.light();
                switchCambioBack.IsChecked = false;
            }

        }

    }
}
