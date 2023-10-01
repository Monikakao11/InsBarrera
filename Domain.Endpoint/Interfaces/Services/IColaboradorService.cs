using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IColaboradorService
    {
        List<Colaborador> GetAll();

        Colaborador CreateColaborador(Colaborador nuevoColaborador);

        void DeleteColaborador(Guid Id);

        void UpdateColaborador(Guid Id, Colaborador nuevosRegistros);

    }
}
