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
    public enum ContactAddressType
    {
        None = 0,
        Mailing = 1,
        Shipping = 2
    }
}
