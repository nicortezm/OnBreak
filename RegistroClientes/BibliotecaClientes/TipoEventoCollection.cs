using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class TipoEventoCollection : List<TipoEvento>
    {
        public TipoEventoCollection()
        {

        }
        public TipoEvento GetTipoEventoCollection(int id, TipoEventoCollection lista)
        {
            try
            {
                return lista.First(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
