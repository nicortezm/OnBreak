using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BibliotecaClientes
{
    public enum TipoEmpresa
    {
        Seleccione,
        SPA,
        EIRL,
        Limitada,
        [Description("Sociedad Anonima")]
        SociedadAnonima
    }

    public enum ActividadEmpresa
    {
        Seleccione,
        Agropecuaria,
        Mineria,
        Manufactura,
        Comercio,
        Hoteleria,
        Alimentos,
        Transporte,
        Servicios
    }
}
