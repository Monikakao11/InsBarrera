using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
////trabajado por Diego Baltodano
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