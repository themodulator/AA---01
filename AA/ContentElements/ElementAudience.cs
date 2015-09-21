using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.ContentElements
{
    public enum ElementAudience
    {
        None = 0,
        Anonymous = 1,
        Authenticated = 2,
        Custom = 4
    }
}
