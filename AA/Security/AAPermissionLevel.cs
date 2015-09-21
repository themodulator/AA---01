using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.Security
{
    public enum AAPermissionLevel
    {
        None = 0,
        Container = 1,
        Children = 2
    }
}
