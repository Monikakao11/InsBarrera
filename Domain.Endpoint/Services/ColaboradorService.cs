using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Services
{
    public class ColaboradorService : IColaboradorService
    {

        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }


        public Colaborador CreateColaborador(Colaborador nuevoColaborador)
        {
            Colaborador newColaborador = new Colaborador()
            {
                Id = Guid.NewGuid(),
                PrimerNombre = nuevoColaborador.PrimerNombre,
                SegundoNombre = nuevoColaborador.SegundoNombre,
                PrimerApellido = nuevoColaborador.PrimerApellido,
                SegundoApellido = nuevoColaborador.SegundoApellido,
                Correo = nuevoColaborador.Correo,
                Estado = nuevoColaborador.Estado,
                Sexo = nuevoColaborador.Sexo,
                UserName = nuevoColaborador.UserName,
                Contraseña = nuevoColaborador.Contraseña,
            };
            _colaboradorRepository.Create(newColaborador);
            return newColaborador;
        }

        public void DeleteColaborador(Guid Id)
        {
            _colaboradorRepository.Delete(Id);
        }

        public List<Colaborador> GetAll()
        {
            return _colaboradorRepository.Get();
        }

        public void UpdateColaborador(Guid Id, Colaborador nuevosRegistros)
        {
            _colaboradorRepository.UpdateColaborador(Id, nuevosRegistros);
        }
    }
}
