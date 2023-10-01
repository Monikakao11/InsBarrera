using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ColaboradorController : ApiController
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public IHttpActionResult GetColaborador()
        {
            List<Colaborador> colabolador = _colaboradorService.GetAll();

            return Ok(colabolador);
        }

        [HttpPost]
        public IHttpActionResult PostColaborador(Colaborador nuevoColaborador)
        {
            Colaborador newColaborador = _colaboradorService.CreateColaborador(nuevoColaborador);

            return Ok(newColaborador);
        }


        [HttpDelete]
        public IHttpActionResult DeleteColaborador(Guid Id)
        {
            _colaboradorService.DeleteColaborador(Id);

            return Ok("el empleado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdaColaborador(Guid Id, Colaborador nuevosRegistros)
        {
            _colaboradorService.UpdateColaborador(Id, nuevosRegistros);

            return Ok("el empleado ha sido modificado");
        }

    }
}

 
