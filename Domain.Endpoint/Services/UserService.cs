using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _colaboradorRepository;

        public UserService(IUserRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }


        public User CreateColaborador(User nuevoColaborador)
        {
            User newColaborador = new User()
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

        public List<User> GetAll()
        {
            return _colaboradorRepository.Get();
        }

        public void UpdateColaborador(Guid Id, User nuevosRegistros)
        {
            _colaboradorRepository.UpdateColaborador(Id, nuevosRegistros);
        }
    }
}
