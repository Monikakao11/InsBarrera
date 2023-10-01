using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IColaboradorRepository
    {
        List<Colaborador> Get();
        void Create(Colaborador nuevoColaborador);

        void Delete(Guid Id);

        void UpdateColaborador(Guid Id, Colaborador nuevosregistros);
    }
}
