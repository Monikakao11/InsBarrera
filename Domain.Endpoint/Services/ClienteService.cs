using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _clienteRepository = ClienteRepository;
        }

        public Cliente CreateCliente(Cliente nuevoCliente)
        {
            Cliente newCliente = new Cliente()
            {
                Id = Guid.NewGuid(),
                PrimerNombre = nuevoCliente.PrimerNombre,
                SegundoNombre = nuevoCliente.SegundoNombre,
                PrimerApellido = nuevoCliente.PrimerApellido,
              SegundoApellido= nuevoCliente.SegundoApellido
                
            };

            _clienteRepository.Create(newCliente);
            return newCliente;
        }

       

        public void DeleteCliente(Guid Id)
        {
            _clienteRepository.Delete(Id);
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.Get();
        }

        public void UpdateCliente(Guid Id, Cliente nuevosCampos)
        {
            _clienteRepository.UpdateCliente(Id, nuevosCampos);  
        }

    }
}
