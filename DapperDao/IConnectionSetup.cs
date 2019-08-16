using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperDao
{
    public interface IConnectionSetup: IDisposable
    {
        IDbConnection GetConnection { get;  }
    }
}
