using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IClienteService
    {
        List<Cliente> GetAll();

        Cliente CreateCliente(Cliente nuevoCliente);

        void DeleteCliente(Guid Id);

        void UpdateCliente(Guid Id, Cliente nuevosCampos);
    }
}
