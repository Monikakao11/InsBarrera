using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProveedorController : ApiController
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public IHttpActionResult GetProveedor()
        {
            List<Proveedor> proveedor = _proveedorService.GetAll();

            return Ok(proveedor);
        }

        [HttpPost]
        public IHttpActionResult PostProveedor(Proveedor nuevoProveedor)  
        {
            Proveedor newProveedor = _proveedorService.CreateProveedor(nuevoProveedor);

            return Ok(newProveedor);
        }


        [HttpDelete]
        public IHttpActionResult DeleteProveedor(Guid Id)
        {
            _proveedorService.DeleteProveedor(Id);

            return Ok("el Proveedor ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateProveedor(Guid Id, Proveedor nuevosCampos)
        {
            _proveedorService.UpdateProveedor(Id, nuevosCampos);

            return Ok("el proveedor ha sido modificado");
        }

    }
}
