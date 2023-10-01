using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly List<Cliente> dataCliente = new List<Cliente>();

        public ClienteRepository()
        {
            var Cliente1 = new Cliente
            {
                Id = Guid.NewGuid(),
                PrimerNombre = "Asimit",
                SegundoNombre = "miguel",
                PrimerApellido="Sanchez",
                SegundoApellido = "Fernandez",
             
            };

            dataCliente.Add(Cliente1);
        }

        public void Create(Cliente nuevoCliente)
        {
            dataCliente.Add(nuevoCliente);
        }

       

        public void Delete(Guid Id)
        {
            var ClienteDelete = dataCliente.FirstOrDefault(e => e.Id == Id);

            if (ClienteDelete!=null)
            {
                dataCliente.Remove(ClienteDelete);
            }
        }

        public List<Cliente> Get()
        {
            return dataCliente;
        }

        public void UpdateCliente(Guid Id, Cliente nuevosCampos)
        {
            var UpdateCliente = dataCliente.FirstOrDefault(e => e.Id == Id);

            if (UpdateCliente!=null)
            {
                UpdateCliente.PrimerNombre = nuevosCampos.PrimerNombre;
                UpdateCliente.SegundoNombre = nuevosCampos.SegundoNombre;
                UpdateCliente.PrimerApellido = nuevosCampos.PrimerApellido;
                UpdateCliente.SegundoApellido = nuevosCampos.SegundoApellido;
              
            }
        }
    }
}
