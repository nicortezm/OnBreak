﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class ClienteCollection: List<Cliente>
    {
        public ClienteCollection()
        {

        }

        public bool Existe(int rut)
        {
            try
            {
                //this.First(c => c.Rut == rut);
                this.First(c => c.Rut == rut);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Cliente BuscarCliente(int rut)
        {
            try
            {

                Cliente cliente = this.First(c => c.Rut == rut);
                return cliente;
            }
            catch (Exception)
            {

                return null;
            }

        }
        public bool TieneContrato(int rut) //terminar
        {
            try
            {
                if (Existe(rut))
                {
                    Cliente cliente = this.First(c => c.Rut == rut);
                    return cliente.Contrato.EstaVigente;
                }
                else
                {
                    return false;
                }




            }
            catch (Exception)
            {

                return false;
            }

        }


    }
    
}
