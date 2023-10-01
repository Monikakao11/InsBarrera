using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Services;

namespace Domain.Endpoint.Services
{
    public class CatProductoService : ICatProductoService
    {
        private readonly ICatProductoRepository _catproductoRepository;

        public CatProductoService(ICatProductoRepository CatProductoRepository)
        {
            _catproductoRepository = CatProductoRepository;
        }

        public void Create(CatProducto nuevoCatProducto)
        {
            throw new NotImplementedException();
        }

        public CatProducto CreateCatProducto(CatProducto nuevoCatProducto)
        {
            CatProducto newCatProducto = new CatProducto()
            {
                Id = Guid.NewGuid(),
                Descripcion = nuevoCatProducto.Descripcion,
                Estado = nuevoCatProducto.Estado,
                Precio = nuevoCatProducto.Precio

            };

            _catproductoRepository.Create(newCatProducto);
            return newCatProducto;
        }

      

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCatProducto(Guid Id)
        {
            _catproductoRepository.Delete(Id);
        }

        public List<CatProducto> Get()
        {
            throw new NotImplementedException();
        }

        public List<CatProducto> GetAll()
        {
            return _catproductoRepository.Get();
        }

        public void UpdateCatProducto(Guid Id, CatProducto nuevosRegistros)
        {
            _catproductoRepository.UpdateCatProducto(Id, nuevosRegistros);
        }  
    }
}
