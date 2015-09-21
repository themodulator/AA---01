using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.ContactInfo
{
    public enum ContactPhoneTypes
    {
        None = 0,
        Primary = 1,
        Home = 2,
        Work = 4,
        Mobile = 8
    }
}
