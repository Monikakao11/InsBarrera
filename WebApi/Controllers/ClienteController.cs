﻿//Controlador de el catálogo Cliente,
//elaborado por: Mónica Gutiérrez Álvarez
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> GetCliente()
        {
            List<Cliente> cliente = await _clienteService.GetAll();

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

            return Ok("El cliente seleccionado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdateCliente(Guid Id, Cliente nuevosRegistros)
        {
            _clienteService.UpdateCliente(Id, nuevosRegistros);

            return Ok("El cliente seleccinado ha sido modificado");
        }

    }
}
