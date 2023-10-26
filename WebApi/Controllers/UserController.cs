using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _colaboradorService;

        public UserController(IUserService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet]
        public IHttpActionResult GetColaborador()
        {
            List<User> colabolador = _colaboradorService.GetAll();

            return Ok(colabolador);
        }

        [HttpPost]
        public IHttpActionResult PostColaborador(User nuevoColaborador)
        {
            User newColaborador = _colaboradorService.CreateColaborador(nuevoColaborador);

            return Ok(newColaborador);
        }


        [HttpDelete]
        public IHttpActionResult DeleteColaborador(Guid Id)
        {
            _colaboradorService.DeleteColaborador(Id);

            return Ok("el empleado ha sido eliminado");
        }

        [HttpPut]
        public IHttpActionResult UpdaColaborador(Guid Id, User nuevosRegistros)
        {
            _colaboradorService.UpdateColaborador(Id, nuevosRegistros);

            return Ok("el empleado ha sido modificado");
        }

    }
}

 
