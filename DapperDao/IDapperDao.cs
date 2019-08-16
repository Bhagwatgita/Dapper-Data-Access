using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDao
{
    public interface IDapperDao
    {
        void PowerOn();
        void PowerOff();
        void GetConnection();
    }
}
