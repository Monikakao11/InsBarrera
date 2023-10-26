using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
///Realizado Por Diego Baltodano :D Octubre 2023
namespace WebApi.Controllers
{
    public class CatProductoController : ApiController
    {
        private readonly ICatProductoService _catproductoService;

        public CatProductoController(ICatProductoService catproductoService)
        {
            _catproductoService = catproductoService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCatProducto()
        {
            List<CatProducto> catproducto =await _catproductoService.GetAll();

            return Ok(catproducto);
        }

        [HttpPost]
        public IHttpActionResult PostCatProducto(CatProducto nuevoCatProducto)  
        {
            CatProducto newCatProducto = _catproductoService.CreateCatProducto(nuevoCatProducto);

            return Ok(newCatProducto);
        }


        [HttpDelete]
        public IHttpActionResult DeleteCatProducto(Guid Id)
        {
            _catproductoService.DeleteCatProducto(Id);

            return Ok("La Categoria seleccionada ha sido eliminada");
        }

        [HttpPut]
        public IHttpActionResult UpdateCatProducto(Guid Id, CatProducto nuevosRegistros)
        {
            _catproductoService.UpdateCatProducto(Id, nuevosRegistros);

            return Ok("La Categoria seleccinada ha sido modificada");
        }
       
    }
}
