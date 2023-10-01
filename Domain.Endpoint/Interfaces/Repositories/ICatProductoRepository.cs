using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface ICatProductoRepository
    {
        List<CatProducto> Get();

        void Create(CatProducto nuevoCatProducto);

        void Delete(Guid Id);

        void UpdateCatProducto(Guid Id, CatProducto nuevosRegistros);
       
    }
}
