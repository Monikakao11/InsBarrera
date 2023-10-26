using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Repositories;
using System.Linq;
///Trabajado por Diego Baltodano Octubre 2023 :D
namespace Infrastructure.Endpoint.Data.Repositories
{
    public class CatProductoRepository : ICatProductoRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;

        public CatProductoRepository(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;

        }

        public void CreateCatProducto(CatProducto nuevoCatProducto)
        {
            

            const string sqlQuery = "INSERT INTO TblCategoria (IdCategoria, Descripcion, Estado, FechaCreacion) Values (@IdCategoria, @Descripcion, @Estado, @FechaCreacion)";
            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdCategoria",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoCatProducto.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Descripcion",

                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevoCatProducto.Descripcion

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",

                    SqlDbType =SqlDbType.Int,
                    Value = nuevoCatProducto.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",

                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoCatProducto.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();


        }

        public void DeleteCatProducto(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM TblCategoria WHERE IdCategoria = @IdCategoria";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdCategoria",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }


        public async Task<List<CatProducto>> Get()
        {
            string query = "SELECT * FROM TblCategoria;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(query);
            List<CatProducto> Catp = dataTable.AsEnumerable().Select(MapEntityFromDataRow).ToList();

            return Catp;
        }

        private CatProducto MapEntityFromDataRow(DataRow row)
        {
            return new CatProducto()
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdCategoria"),
                Descripcion = _sqlDbConnection.GetDataRowValue<string>(row, "Descripcion"),
                Estado = _sqlDbConnection.GetDataRowValue<int>(row, "Estado"),
                FechaCreacion = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaCreacion"),
            };
        }

        public void UpdateCatProducto(Guid Id, CatProducto nuevoCatProducto)
        {
            const string sqlQuery = "UPDATE TblCategoria SET  Descripcion = @Descripcion, Estado = @Estado,FechaCreacion = @FechaCreacion WHERE IdCategoria = @IdCategoria";
            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdCategoria",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoCatProducto.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Descripcion",

                    SqlDbType =SqlDbType.NVarChar,
                    Value = nuevoCatProducto.Descripcion

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",

                    SqlDbType =SqlDbType.Int,
                    Value = nuevoCatProducto.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",

                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoCatProducto.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();

        }


    }
}

