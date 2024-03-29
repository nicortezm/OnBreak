﻿using System;
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
            TipoEvento tipev = new TipoEvento();
            tipev = new TipoEvento { Id = 0001, Nombre = "Seleccione", ValorBase = 0, PersonalBase = 0 };
            Add(tipev);
            tipev = new TipoEvento { Id = 1111, Nombre = "Cumpleaños", ValorBase = 4, PersonalBase = 12 };
            Add(tipev);
            tipev = new TipoEvento { Id = 1112, Nombre = "Casamiento", ValorBase = 8, PersonalBase = 30 };
            Add(tipev);
            tipev = new TipoEvento { Id = 1113, Nombre = "Fiesta de Gala", ValorBase = 12, PersonalBase = 40 };
            Add(tipev);
        }
        public TipoEvento GetTipoEventoCollection(int id, TipoEventoCollection lista)
        {
            try
            {
                return lista.First(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public string NomEvento(int id)
        {
            try
            {
                TipoEvento evento = this.First(x => x.Id == id);
                return evento.Nombre;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public int GetidEvento(string nombre)
        {
            try
            {
                TipoEvento evento = this.First(x => x.Nombre.ToString() == nombre);
                return evento.Id;
            }
            catch (Exception)
            {

                return 0;
            }
        }

    }
}