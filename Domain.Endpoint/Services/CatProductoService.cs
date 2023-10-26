using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Services;
///Trabajado por Diego Baltodano Octubre 2023 :D
namespace Domain.Endpoint.Services
{
public class CatProductoService : ICatProductoService
    {
        private readonly ICatProductoRepository _catproductoRepository;

        public CatProductoService(ICatProductoRepository CatProductoRepository)
        {
            _catproductoRepository = CatProductoRepository;
        }
        public CatProducto CreateCatProducto(CatProducto nuevoCatProducto)
        {
            CatProducto newCatProducto = new CatProducto()
            {
                Id = Guid.NewGuid(),
                Descripcion = nuevoCatProducto.Descripcion,
                Estado = nuevoCatProducto.Estado,
                FechaCreacion = nuevoCatProducto.FechaCreacion

            };

            _catproductoRepository.CreateCatProducto(newCatProducto);
            return newCatProducto;
        }



        public void DeleteCatProducto(Guid Id)
        {
            _catproductoRepository.DeleteCatProducto(Id);
        }



        public Task<List<CatProducto>> GetAll()
        {
            return _catproductoRepository.Get();
        }

        public void UpdateCatProducto(Guid Id, CatProducto nuevosRegistros)
        {
            _catproductoRepository.UpdateCatProducto(Id, nuevosRegistros);
        }
    }
}
