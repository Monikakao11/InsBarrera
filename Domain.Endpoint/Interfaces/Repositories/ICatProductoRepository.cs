using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
///Trabajado por Diego Baltodano Octubre 2023 :D
namespace Domain.Endpoint.Interfaces.Repositories
{
   public interface ICatProductoRepository
    {
        Task<List<CatProducto>> Get();


       void CreateCatProducto(CatProducto nuevoCatProducto);
        
        void DeleteCatProducto(Guid Id);

      void UpdateCatProducto(Guid Id, CatProducto nuevosRegistros);
       
    }
}
