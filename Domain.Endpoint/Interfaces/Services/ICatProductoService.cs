using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
///Trabajado por Diego Baltodano Octubre 2023  :D 
namespace Domain.Endpoint.Interfaces.Services
{
     public interface ICatProductoService
    {
        Task<List<CatProducto>> GetAll();

        CatProducto CreateCatProducto(CatProducto nuevoCatProducto);

        void DeleteCatProducto(Guid Id);

        void UpdateCatProducto(Guid Id, CatProducto nuevoRegistros);
    }
}
