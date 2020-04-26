using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class ContratoCollection : List<Contrato>
    {
        public ContratoCollection()
        {

        }
        public Contrato BuscarContrato(int numcont)
        {
            try
            {
                return this.First(x => x.NumeroContrato == numcont);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
