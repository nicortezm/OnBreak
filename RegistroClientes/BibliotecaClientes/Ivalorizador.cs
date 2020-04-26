using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public interface Ivalorizador
    {
        double ValorizaContrato(int asistentes, int personalAdicional, TipoEventoCollection listaEventos);
    }
}
