using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IUserService
    {
        List<User> GetAll();

        User CreateColaborador(User nuevoColaborador);

        void DeleteColaborador(Guid Id);

        void UpdateColaborador(Guid Id, User nuevosRegistros);

    }
}
