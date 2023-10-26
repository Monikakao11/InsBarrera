using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> Get();
        void Create(User nuevoColaborador);

        void Delete(Guid Id);

        void UpdateColaborador(Guid Id, User nuevosregistros);
    }
}
