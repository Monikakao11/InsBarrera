//Repositorio del catálogo Cliente elaborado por: Mónica Gutiérrez Álvarez
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        public ClienteRepository(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }

        public void CreateCliente(Cliente nuevoCliente)
        {

            const string sqlQuery = "INSERT INTO TblCliente (IdCliente, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido," +
                "Correo, Telefono, Estado, FechaCreacion) Values (@IdCliente, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido," +
                "@Correo, @Telefono, @Estado, @FechaCreacion)";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdCliente",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoCliente.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevoCliente.PrimerNombre
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoCliente.SegundoNombre
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoCliente.PrimerApellido
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoCliente.SegundoApellido
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Correo",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoCliente.Correo
                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Telefono",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoCliente.Telefono
                },
                          new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoCliente.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoCliente.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        public void DeleteCliente(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM TblCliente WHERE IdCliente = @IdCliente";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCliente",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        //Ver
        public async Task<List<Cliente>> Get()
        {

            string query = "SELECT * FROM TblCliente;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(query);
            List<Cliente> Ct = dataTable.AsEnumerable().Select(MapEntityFromDataRow).ToList();

            return Ct;

        }

        public Cliente MapEntityFromDataRow(DataRow row)
        {
            return new Cliente()
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdCliente"),
                PrimerNombre = _sqlDbConnection.GetDataRowValue<string>(row, "PrimerNombre"),
                SegundoNombre = _sqlDbConnection.GetDataRowValue<string>(row, "SegundoNombre"),
                PrimerApellido = _sqlDbConnection.GetDataRowValue<string>(row, "PrimerApellido"),
                SegundoApellido = _sqlDbConnection.GetDataRowValue<string>(row, "SegundoApellido"),
                Correo = _sqlDbConnection.GetDataRowValue<string>(row, "Correo"),
                Telefono = _sqlDbConnection.GetDataRowValue<int>(row, "Telefono"),
                Estado = _sqlDbConnection.GetDataRowValue<int>(row, "Estado"),
                FechaCreacion = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaCreacion"),

            };

        }

        public void UpdateCliente(Guid Id, Cliente nuevosRegistros)
        {
            const string sqlQuery = "UPDATE TblCliente SET  PrimerNombre = @PrimerNombre, SegundoNombre = @SegundoNombre, PrimerApellido = @PrimerApellido, SegundoApellido = @SegundoApellido, Correo = @Correo, Telefono = @Telefono, Estado = @Estado, FechaCreacion = @FechaCreacion WHERE IdCliente = @IdCliente";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdCliente",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevosRegistros.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerNombre",
                    SqlDbType =SqlDbType.NVarChar,
                    Value =nuevosRegistros.PrimerNombre
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoNombre",
                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevosRegistros.SegundoNombre
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerApellido",
                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevosRegistros.PrimerApellido
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoApellido",
                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevosRegistros.SegundoApellido
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Correo",
                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevosRegistros.Correo
                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Telefono",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevosRegistros.Telefono
                },
                          new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevosRegistros.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevosRegistros.FechaCreacion
                }
                  };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }
    }
}
