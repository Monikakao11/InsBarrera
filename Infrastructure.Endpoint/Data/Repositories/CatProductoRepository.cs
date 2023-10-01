using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Repositories;
using System.Linq;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class CatProductoRepository : ICatProductoRepository 
    {
        private readonly List<CatProducto> dataCatProducto = new List<CatProducto>();

        public CatProductoRepository()
        {
            var CatProducto1 = new CatProducto
            {
                Id = Guid.NewGuid(),
                Descripcion = "Barra de chocolate",
                Estado = "10 unidades de 20cm",
                Precio = 120 ,

            };

            dataCatProducto.Add(CatProducto1);
        }

        public void Create(CatProducto nuevoCatProducto)
        {
            dataCatProducto.Add(nuevoCatProducto);
        }



        public void Delete(Guid Id)
        {
            var CatProductoDelete = dataCatProducto.FirstOrDefault(e => e.Id == Id);

            if (CatProductoDelete != null)
            {
                dataCatProducto.Remove(CatProductoDelete);
            }
        }

        public List<CatProducto> Get()
        {
            return dataCatProducto;
        }

        public void UpdateCatProducto(Guid Id, CatProducto nuevosRegistros)
        {
          var UpdateCatProducto = dataCatProducto.FirstOrDefault(e => e.Id == Id);

         if (UpdateCatProducto != null)
         {
              UpdateCatProducto.Descripcion = nuevosRegistros.Descripcion;
              UpdateCatProducto.Estado = nuevosRegistros.Estado;
              UpdateCatProducto.Precio = nuevosRegistros.Precio;

         }
        }
    }
}

