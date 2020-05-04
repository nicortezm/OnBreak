using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class Contrato : Ivalorizador
    {

        private int _ValorBase { get; set; }
        private int _PersonalBase { get; set; }

        public long NumeroContrato { get; set; }
        public string Creacion { get; set; }
        public string Termino { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public string Direccion { get; set; }
        public Boolean EstaVigente { get; set; }
        public int IdTipo { get; set; }
        public string Observaciones { get; set; }
    


        /* Propiedades customizadas */
        public int ValorBaseTipoEvento { get { return _ValorBase; } }
        public int PersonalBaseEvento { get { return _PersonalBase; } }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            NumeroContrato = 0;
            Creacion = string.Empty;
            Termino = string.Empty;
            FechaHoraInicio = DateTime.Now;
            FechaHoraTermino = DateTime.Now;
            Direccion = string.Empty;
            EstaVigente = false;
            IdTipo = 0;
            Observaciones = string.Empty;

        }
        /// <summary>
        /// Método declarado en la interfaz
        /// </summary>
        /// <param name="asistentes"></param>
        /// <param name="personalAdicional"></param>
        /// <param name="listaEventos"></param>
        /// <returns></returns>
        public double ValorizaContrato(int asistentes, int personalAdicional, TipoEventoCollection listaEventos)
        {
            LeerPropiedadesReadOnly(listaEventos);
            int valorAsistentes = 0;
            double valorPersonalAdicional = 0;

            // if para sacar el recargo en UF de los asistentes
            if (asistentes > 1 && asistentes < 20)
            {
                valorAsistentes = 3 * asistentes;
            }
            else if (asistentes > 21 && asistentes < 50)
            {
                valorAsistentes = 5 * asistentes;
            }
            else
            {
                valorAsistentes = (asistentes - (asistentes % 20)) / 20;
            }


            //if para sacar el recargo en uf del personal adicional

            if (personalAdicional <= 3)
            {
                valorPersonalAdicional = personalAdicional;
            }
            else if (personalAdicional == 4)
            {
                valorPersonalAdicional = 3.5;
            }
            else
            {
                valorPersonalAdicional = 3.5 + 0.5 * (personalAdicional - 4);
            }

            return ValorBaseTipoEvento + valorAsistentes + valorPersonalAdicional;


        }
        /// <summary>
        /// Método para simular la lectura de una tabla de tipo
        /// Le paso la colección creada en la app WPF para extraer los datos de la clase
        /// </summary>
        /// <param name="listaEventos"></param>
        private void LeerPropiedadesReadOnly(TipoEventoCollection listaEventos)
        {
            TipoEventoCollection te = new TipoEventoCollection();
            _ValorBase = te.GetTipoEventoCollection(IdTipo, listaEventos).ValorBase;
            _PersonalBase = te.GetTipoEventoCollection(IdTipo, listaEventos).PersonalBase;
        }
    }
}
