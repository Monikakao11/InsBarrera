using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IHttpActionResult GetProducto()
        {
            List<Producto> producto = _productoService.GetAll();

            return Ok(producto);
        }

        [HttpPost]
        public IHttpActionResult PostProducto(Producto nuevoProducto)  
        {
            Producto newProducto = _productoService.CreateProducto(nuevoProducto);

            return Ok(newProducto);
        }


        [HttpDelete]
        public IHttpActionResult DeleteProducto(Guid Id)
        {
            _productoService.DeleteProducto(Id);

            return Ok("El producto ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateProducto(Guid Id, Producto nuevosRegistros)
        {
            _productoService.UpdateProducto(Id, nuevosRegistros);

            return Ok("El producto ha sido modificado");
        }

    }
}
