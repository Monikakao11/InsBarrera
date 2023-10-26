using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IHttpActionResult GetCliente()
        {
            List<Cliente> cliente = _clienteService.GetAll();

            return Ok(cliente);
        }

        [HttpPost]
        public IHttpActionResult PostCliente(Cliente nuevoCliente)  
        {
            Cliente newCliente = _clienteService.CreateCliente(nuevoCliente);

            return Ok(newCliente);
        }


        [HttpDelete]
        public IHttpActionResult DeleteCliente(Guid Id)
        {
            _clienteService.DeleteCliente(Id);

            return Ok("Estiamdo el Cliente ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateCliente(Guid Id, Cliente nuevosCampos)
        {
            _clienteService.UpdateCliente(Id, nuevosCampos);

            return Ok("Estimado el Cliente ha sido modificado");
        }

    }
}
