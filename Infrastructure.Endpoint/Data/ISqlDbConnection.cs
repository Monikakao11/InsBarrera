using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data
{
    public interface ISqlDbConnection
    {
        void CloseConnection();
        SqlDataAdapter CreateDataApdapter(string query);
        Task<DataTable> ExecuteQueryCommandAsync(string sql);
        T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default);
        void OpenConnection();

        SqlCommand TraerConsulta(string sql);
    }
}
