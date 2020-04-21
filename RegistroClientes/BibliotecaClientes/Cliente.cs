using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BibliotecaClientes
{
    public class Cliente
    {
        //private List<Cliente> clientList = new List<Cliente>();
        //ClienteCollection clic = new ClienteCollection();
        public int Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public ActividadEmpresa Actividad { get; set; }
        public TipoEmpresa Tipo { get; set; }
        public int Telefono { get; set; }
      

        public Cliente()
        {
            this.Init();

        }
        private void Init()
        {
            Rut = 0;
            RazonSocial = String.Empty;
            Direccion = String.Empty;
            Telefono = 0;
            Actividad = ActividadEmpresa.seleccione;
            Tipo = TipoEmpresa.seleccione;
        }

        //public void BuscarCLient(String rut)
        //{
        //    foreach (var cl in clientList)
        //    {
        //        if (cl.Rut==rut)
        //        {

        //        }
        //    }

        //}
        //public void AgregarClient(Cliente cli)
        //{
        //    clientList.Add(cli);

        //}
        //hola mundo
       
    }
}
