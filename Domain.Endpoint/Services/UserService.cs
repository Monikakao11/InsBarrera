﻿//Realizado por Joshua Chavez
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using Domain.Endpoint.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Endpoint.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User nuevoUser)
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                PrimerNombre = nuevoUser.PrimerNombre,
                SegundoNombre = nuevoUser.SegundoNombre,
                PrimerApellido = nuevoUser.PrimerApellido,
                SegundoApellido = nuevoUser.SegundoApellido,
                Correo = nuevoUser.Correo,
                IdRol = nuevoUser.IdRol,
                Estado = nuevoUser.Estado,
                Sexo = nuevoUser.Sexo,
                UserName = nuevoUser.UserName,
                Contraseña = nuevoUser.Contraseña,
                FechaCreacion = nuevoUser.FechaCreacion

            };

            _userRepository.CreateUser(newUser);
            return newUser;
        }

        public void DeleteUser(Guid Id)
        {
            _userRepository.DeleteUser(Id);
        }

        public Task<List<User>> GetAll()
        {
            return _userRepository.Get();
        }

        public void UpdateUser(Guid Id, User nuevoRegistros)
        {
            _userRepository.UpdateUser(Id, nuevoRegistros);
        }
    }
}
