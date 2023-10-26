//hecho por Cesar Rodriguez
using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {

        private readonly ISqlDbConnection _sqlDbConnection;
        public ProveedorRepository(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }

        public void CreateProveedor(Proveedor nuevoProveedor)
        {
            const string sqlQuery = "INSERT INTO TblProveedor(IdProveedor, NombreCompañia, Correo, Telefono, Estado, FechaCreacion) Values (@IdProveedor, @NombreCompañia, @Correo, @Telefono, @Estado, @FechaCreacion)";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdProveedor",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoProveedor.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@NombreCompañia",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevoProveedor.NombreCompañia
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Correo",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoProveedor.Correo
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Telefono",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoProveedor.Telefono
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoProveedor.Estado
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoProveedor.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProveedor(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM TblProveedor WHERE IdProveedor = @IdProveedor";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProveedor",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        public async Task<List<Proveedor>> Get()
        {
            string query = "SELECT * FROM TblProveedor;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(query);
            List<Proveedor> Ctec = dataTable.AsEnumerable().Select(MapEntityFromDataRow).ToList();

            return Ctec;
        }

        public Proveedor MapEntityFromDataRow(DataRow row)
        {
            return new Proveedor()
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdProveedor"),
                NombreCompañia = _sqlDbConnection.GetDataRowValue<string>(row, "NombreCompañia"),
                Correo = _sqlDbConnection.GetDataRowValue<string>(row, "Correo"),
                Telefono = _sqlDbConnection.GetDataRowValue<int>(row, "Telefono"),
                Estado = _sqlDbConnection.GetDataRowValue<int>(row, "Estado"),
                FechaCreacion = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaCreacion"),

            };
        }

        public void UpdateProveedor(Guid Id, Proveedor nuevosRegistros)
        {
            const string sqlQuery = "UPDATE TblProveedor SET  NombreCompañia = @NombreCompañia, Correo = @Correo, Telefono = @Telefono, FechaCreacion = @FechaCreacion WHERE IdProveedor = @IdProveedor";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdProveedor",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value =nuevosRegistros.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@NombreCompañia",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevosRegistros.NombreCompañia
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Correo",
                    SqlDbType =SqlDbType.VarChar,
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
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.Estado
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }
    }
}




