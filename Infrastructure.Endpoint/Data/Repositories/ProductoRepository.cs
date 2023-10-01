using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Repositories;
using System.Linq;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly List<Producto> dataProducto = new List<Producto>();

        public ProductoRepository()
        {
            var Producto1 = new Producto
            {
                Id = Guid.NewGuid(),
                NombreProducto = "Levadura",
                Descripcion = "2 libras",
                Preciocompra =45 ,
                Precioventa = 120,
                Estado="en stock 18 libras",

            };

            dataProducto.Add(Producto1);
        }

        public void Create(Producto nuevoProducto)
        {
            dataProducto.Add(nuevoProducto);
        }



        public void Delete(Guid Id)
        {
            var ProductoDelete = dataProducto.FirstOrDefault(e => e.Id == Id);

            if (ProductoDelete != null)
            {
                dataProducto.Remove(ProductoDelete);
            }
        }

        public List<Producto> Get()
        {
            return dataProducto;
        }

        public void UpdateProducto(Guid Id, Producto nuevosRegistros)
        {
          var UpdateProducto = dataProducto.FirstOrDefault(e => e.Id == Id);

         if (UpdateProducto != null)
         {
                UpdateProducto.NombreProducto = nuevosRegistros.NombreProducto;
                UpdateProducto.Descripcion = nuevosRegistros.Descripcion;
                UpdateProducto.Preciocompra = nuevosRegistros.Preciocompra; 
                UpdateProducto.Precioventa = nuevosRegistros.Precioventa;
                UpdateProducto.Estado= nuevosRegistros.Estado;

         }
        }
    }
}

