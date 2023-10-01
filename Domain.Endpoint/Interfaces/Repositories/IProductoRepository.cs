using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> Get();

        void Create(Producto nuevoProducto);

        void Delete(Guid Id);

        void UpdateProducto(Guid Id, Producto nuevosRegistros);
       
    }
}
