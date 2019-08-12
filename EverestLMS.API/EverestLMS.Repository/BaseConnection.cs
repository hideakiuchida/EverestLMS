using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
