//Elaborado por Mónica Gutiérrez Álvarez
using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IClienteService
    {

        Task<List<Cliente>> GetAll();

        Cliente CreateCliente(Cliente nuevoCliente);

        void DeleteCliente(Guid Id);

        void UpdateCliente(Guid Id, Cliente nuevoRegistros);
    }
}
