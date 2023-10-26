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
    public class UserResopitory : IUserRepository
    {
        private readonly ISqlDbConnection _sqlDbConnection;
        public UserResopitory(ISqlDbConnection sqlDbConnection)
        {
            _sqlDbConnection = sqlDbConnection;
        }

        public void CreateUser(User nuevoUser)
        {
            const string sqlQuery = "INSERT INTO db_Catalogo.TblUsuario (IdUsuario, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido," +
               "Correo, IdRol, Estado, Sexo, Username, Contraseña, FechaCreacion) Values (@IdUsuario, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido," +
               "@Correo, @IdRol, @Estado, @Sexo, @Username, @Contraseña, @FechaCreacion)";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdUsuario",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevoUser.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevoUser.PrimerNombre
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.SegundoNombre
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.PrimerApellido
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.SegundoApellido
                },
                      new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Correo",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.Correo
                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@IdRol",
                    SqlDbType =SqlDbType.UniqueIdentifier,
                    Value = nuevoUser.IdRol
                },
                          new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Estado",
                    SqlDbType =SqlDbType.Int,
                    Value = nuevoUser.Estado

                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Sexo",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.Sexo

                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Username",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.UserName

                },
                            new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Contraseña",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevoUser.Contraseña

                },

                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@FechaCreacion",
                    SqlDbType =SqlDbType.DateTime,
                    Value = nuevoUser.FechaCreacion
                }

            };

            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(Guid Id)
        {
            //Aqui haces una consulta donde comparas los ID
            string delec = "DELETE FROM db_Catalogo.TblUsuario WHERE IdUsuario = @IdUsuario";
            SqlCommand sqlCommand = _sqlDbConnection.TraerConsulta(delec);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@IdUsuario",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = Id
            };
            sqlCommand.Parameters.Add(parameter);
            sqlCommand.ExecuteNonQuery();
        }

        public async Task<List<User>> Get()
        {
            string query = "SELECT * FROM db_Catalogo.TblUsuario;";
            DataTable dataTable = await _sqlDbConnection.ExecuteQueryCommandAsync(query);
            List<User> Cat = dataTable.AsEnumerable().Select(MapEntityFromDataRow).ToList();

            return Cat;
        }

        public User MapEntityFromDataRow(DataRow row)
        {
            return new User()
            {
                Id = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdUsuario"),
                PrimerNombre = _sqlDbConnection.GetDataRowValue<string>(row, "PrimerNombre"),
                SegundoNombre = _sqlDbConnection.GetDataRowValue<string>(row, "SegundoNombre"),
                PrimerApellido = _sqlDbConnection.GetDataRowValue<string>(row, "PrimerApellido"),
                SegundoApellido = _sqlDbConnection.GetDataRowValue<string>(row, "SegundoApellido"),
                Correo = _sqlDbConnection.GetDataRowValue<string>(row, "Correo"),
                IdRol = _sqlDbConnection.GetDataRowValue<Guid>(row, "IdRol"),
                Estado = _sqlDbConnection.GetDataRowValue<int>(row, "Estado"),
                Sexo = _sqlDbConnection.GetDataRowValue<string>(row, "Sexo"),
                UserName = _sqlDbConnection.GetDataRowValue<string>(row, "Username"),
                Contraseña = _sqlDbConnection.GetDataRowValue<string>(row, "Contraseña"),
                FechaCreacion = _sqlDbConnection.GetDataRowValue<DateTime>(row, "FechaCreacion"),
            };
        }

        public void UpdateUser(Guid Id, User nuevosRegistros)
        {
            const string sqlQuery = "UPDATE db_Catalogo.TblUsuario SET  PrimerNombre = @PrimerNombre, SegundoNombre = @SegundoNombre, PrimerApellido = @PrimerApellido," +
            "SegundoApellido = @SegundoApellido, Correo = @Correo, IdRol = @IdRol, Estado = @Estado, Sexo = @Sexo, Username = @Username, Contraseña = @Contraseña, FechaCreacion = @FechaCreacion WHERE IdUsuario = @IdUsuario";

            SqlCommand cmd = _sqlDbConnection.TraerConsulta(sqlQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    //_Valor del parametro
                    ParameterName ="@IdUsuario",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = nuevosRegistros.Id
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value =nuevosRegistros.PrimerNombre
                },
                new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoNombre",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.SegundoNombre
                },
                  new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@PrimerApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.PrimerApellido
                },
                    new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@SegundoApellido",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.SegundoApellido
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
                    ParameterName ="@IdRol",
                    SqlDbType =SqlDbType.UniqueIdentifier,
                    Value = nuevosRegistros.IdRol
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
                    ParameterName ="@Sexo",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.Sexo

                },
                        new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Username",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.UserName

                },
                            new SqlParameter()
                {
                    Direction = ParameterDirection.Input,
                    ParameterName ="@Contraseña",
                    SqlDbType =SqlDbType.VarChar,
                    Value = nuevosRegistros.Contraseña

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
