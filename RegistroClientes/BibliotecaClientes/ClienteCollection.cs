using System;
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
        public bool EliminarCliente(int rut)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente = BuscarCliente(rut);

                var itemToRemove = this.Single(r => r.Rut == rut);
                this.Remove(itemToRemove);

                /*
                foreach (Cliente cli in lista)
                {
                    if (cli.Rut == rut)
                    {
                        lista.Remove(cli);
                        return true;
                    }
                }
                */
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool ModificarCliente(Cliente cliente)
        {
            try
            {

                int loop = 0;
                
                foreach (Cliente cli in this)
                {
                    if (cli.Rut == cliente.Rut)
                    {
                        this[loop] = cliente;
                        return true;
                    }
                    loop++;
                }
                
                return false;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public string EncontrarNombre(long numcontrato)
        {

            try
            {
                foreach (var cliente in this)
                {
                    foreach (var contrato in cliente.Contrato)
                    {
                        if (numcontrato == contrato.NumeroContrato)
                        {
                            return cliente.NombreContacto;
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {

                return string.Empty;
            }
        }
        public string EncontrarRut(long numcontrato)
        {
            try
            {
                foreach (var cliente in this)
                {
                    foreach (var contrato in cliente.Contrato)
                    {
                        if (numcontrato == contrato.NumeroContrato)
                        {
                            return cliente.Rut.ToString();
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
        public Contrato BuscarContrato(long numcontrato)
        {
            try
            {
                foreach (var cliente in this)
                {
                    foreach (var contrato in cliente.Contrato)
                    {
                        if (numcontrato == contrato.NumeroContrato)
                        {
                            return contrato;
                        }
                    }
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool TieneContrato(int rut) 
        {
            try
            {
                if (Existe(rut))
                {
                    Cliente cliente = this.First(c => c.Rut == rut);
                    if (cliente.Contrato.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
