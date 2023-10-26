using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data
{
    public class SqlDbConnection : ISqlDbConnection
    {
        private static SqlDbConnection _instance;
        public readonly SqlConnection connection;

        private SqlDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSQLServer"].ConnectionString;
            connection = new SqlConnection(connectionString);

            OpenConnection();
        }

        public static SqlDbConnection GetInstance()
        {
            if (_instance is null)
            {
                _instance = new SqlDbConnection();
            }

            return _instance;
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Open) return;

            connection.Open();
        }


        public SqlCommand TraerConsulta(string cmd)
        {
            return new SqlCommand(cmd, connection);
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Closed) return;

            connection.Close();
        }

        public async Task<DataTable> ExecuteQueryCommandAsync(string sql)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            command.Dispose();
            return dt;
        }

        public SqlDataAdapter CreateDataApdapter(string query)
        {
            return new SqlDataAdapter(query, connection);
        }

        public T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default)
        {
            return !row.IsNull(index) ? (T)row[index] : defaultValue;
        }
    }
}
