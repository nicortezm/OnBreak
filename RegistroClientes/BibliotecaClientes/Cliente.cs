using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BibliotecaClientes
{
    public class Cliente{

        public int Rut { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public int Telefono { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public ActividadEmpresa ActividadEmpresa { get; set; }
        public Contrato Contrato { get; set; }

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            Rut = 0;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            MailContacto = string.Empty;
            Telefono = 0;
            TipoEmpresa = TipoEmpresa.Seleccione;
            ActividadEmpresa = ActividadEmpresa.Seleccione;
            Contrato = new Contrato();
        }

    }
}
