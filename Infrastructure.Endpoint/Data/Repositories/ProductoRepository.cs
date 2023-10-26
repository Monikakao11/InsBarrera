//Hecho por Fernando Calderon
using Domain.Endpoint.Entities;
using System.Collections.Generic;
using System;
using Domain.Endpoint.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ISqlDbConnection _sqlDbConnection;
        public ProductoRepository(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }

        public void CreateProducto(Producto nuevoProducto)
        {
            const string sqlQuery = "INSERT INTO db_Catalogo.TblProducto (IdProducto, NombreProducto, Descripcion, IdCategoria, PrecioCompra, PrecioVenta," +
            "Estado, FechaCompra, FechaVencimiento) VALUES (@NombreProducto, @Descripcion, @IdCategoria, @PrecioCompra, @PrecioVenta, @Estado, @FechaCompra, @FechaVencimiento)";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdProducto",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoProducto.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@NombreProducto",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevoProducto.NombreProducto
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Descripcion",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoProducto.Descripcion
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@IdCategoria",
                    SqlDbType =SqlDbType.UniqueIdentifier,
                    Value = nuevoProducto.IdCategoria
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrecioCompra",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoProducto.Preciocompra
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrecioVenta",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoProducto.Precioventa
                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Telefono",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoProducto.Estado
                },
                          new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCompra",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoProducto.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaVencimiento",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoProducto.FechaVencimiento
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProducto(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM db_Catalogo.TblProducto WHERE IdProducto = @IdProducto";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdProducto",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        //Ver
        public async Task<List<Producto>> Get()
        {

            string query = "SELECT * FROM db_Catalogo.TblProducto;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(query);
            List<Producto> Cet = dataTable.AsEnumerable().Select(MapEntityFromDataRow).ToList();

            return Cet;


        }

        public Producto MapEntityFromDataRow(DataRow row)
        {
            Producto producto = new Producto
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdProducto"),
                NombreProducto = _sqlDbConnection.GetDataRowValue<string>(row, "NombreProducto"),
                Descripcion = _sqlDbConnection.GetDataRowValue<string>(row, "Descripcion"),
                IdCategoria = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdCategoria"),
                Preciocompra = _sqlDbConnection.GetDataRowValue<int>(row, "PrecioCompra"),
                Precioventa = _sqlDbConnection.GetDataRowValue<int>(row, "PrecioVenta"),
                Estado = _sqlDbConnection.GetDataRowValue<int>(row, "Estado"),
                FechaCompra = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaCompra"),
                FechaVencimiento = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaVencimiento"),

            };
            return producto;
        }

        public void UpdateProducto(Guid Id, Producto nuevosRegistros)
        {
            const string sqlQuery = "UPDATE db_Catalogo.TblProducto SET  NombreProducto =@NombreProducto, Descripcion = @Descripcion, IdCategoria = @IdCategoria," +
            " PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, Estado = @Estado, FechaCompra = @FechaCompra," +
            " FechaVencimiento = @FechaVencimiento WHERE IdProducto = @IdProducto";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
              new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdProducto",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevosRegistros.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@NombreProducto",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevosRegistros.NombreProducto
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Descripcion",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.Descripcion
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@IdCategoria",
                    SqlDbType =SqlDbType.UniqueIdentifier,
                    Value = nuevosRegistros.IdCategoria
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrecioCompra",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevosRegistros.Preciocompra
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrecioVenta",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevosRegistros.Precioventa
                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Telefono",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevosRegistros.Estado
                },
                          new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCompra",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevosRegistros.Estado

                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaVencimiento",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevosRegistros.FechaVencimiento
                }
            };
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }
    }
}



