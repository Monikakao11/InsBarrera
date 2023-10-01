using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> Get();

        void Create(Cliente nuevoCliente);

        void Delete(Guid Id);

        void UpdateCliente(Guid Id, Cliente nuevosCampos);
    }
}
