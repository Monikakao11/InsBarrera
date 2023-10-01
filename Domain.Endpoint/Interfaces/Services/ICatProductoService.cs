using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface ICatProductoService
    {
        List<CatProducto> GetAll();

        CatProducto CreateCatProducto(CatProducto nuevoCatProducto);

        void DeleteCatProducto(Guid Id);

        void UpdateCatProducto(Guid Id, CatProducto nuevoRegistros);
    }
}
