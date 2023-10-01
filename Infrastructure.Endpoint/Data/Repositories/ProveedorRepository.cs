using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {

        private readonly List<Proveedor> dataProveedor = new List<Proveedor>();

        public ProveedorRepository()
        {
            var Proveedor1 = new Proveedor
            {
                Id = Guid.NewGuid(),
                NombreCompañia = "Sa",
                Correo = "SA@gmail.com",
                Telefono = 98038371,
             
            };

            dataProveedor.Add(Proveedor1);
        }

        public void Create(Proveedor nuevoProveedor)
        {
            dataProveedor.Add(nuevoProveedor);
        }

       

        public void Delete(Guid Id)
        {
            var ProveedorDelete = dataProveedor.FirstOrDefault(e => e.Id == Id);

            if (ProveedorDelete!=null)
            {
                dataProveedor.Remove(ProveedorDelete);
            }
        }

        public List<Proveedor> Get()
        {
            return dataProveedor;
        }

        public void UpdateProveedor(Guid Id, Proveedor nuevosCampos)
        {
            var UpdateProveedor = dataProveedor.FirstOrDefault(e => e.Id == Id);

            if (UpdateProveedor!=null)
            {
                UpdateProveedor.NombreCompañia = nuevosCampos.NombreCompañia;
                UpdateProveedor.Correo = nuevosCampos.Correo;
                UpdateProveedor.Telefono = nuevosCampos.Telefono;
              
            }
        }
    }
}
