using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HRManagement.Application.Common
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
