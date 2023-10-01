using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Services;

namespace Domain.Endpoint.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository ProductoRepository)
        {
            _productoRepository = ProductoRepository;
        }

        public void Create(Producto nuevoProducto)
        {
            throw new NotImplementedException();
        }

        public Producto CreateProducto(Producto nuevoProducto)
        {
            Producto newProducto = new Producto()
            {
                Id = Guid.NewGuid(),
                NombreProducto = nuevoProducto.NombreProducto,
                Descripcion = nuevoProducto.Descripcion,
                Preciocompra= nuevoProducto.Preciocompra,
                Precioventa = nuevoProducto.Precioventa,
                Estado= nuevoProducto.Estado,
                

            };

            _productoRepository.Create(newProducto);
            return newProducto;
        }

      

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProducto(Guid Id)
        {
            _productoRepository.Delete(Id);
        }

        public List<Producto> Get()
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetAll()
        {
            return _productoRepository.Get();
        }

        public void UpdateProducto(Guid Id, Producto nuevosRegistros)
        {
            _productoRepository.UpdateProducto(Id, nuevosRegistros);
        }  
    }
}
