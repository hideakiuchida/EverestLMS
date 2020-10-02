using System.Data;

namespace EverestLMS.Repository
{
    public class BaseConnection
    {
        protected readonly IDbConnection _dbConnection;
        public BaseConnection(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
    }
}
