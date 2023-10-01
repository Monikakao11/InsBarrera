using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IProveedorRepository
    {
        List<Proveedor> Get();

        void Create(Proveedor nuevoProveedor);

        void Delete(Guid Id);

        void UpdateProveedor(Guid Id, Proveedor nuevosCampos);
    }
}
