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
    public enum AAPermissionScope
    {
        None = 0,
        Officers = 1,
        Calendars = 2,
        Notification = 4,
        Meetings = 8,
        Contact = 16,
        Members = 32
    }
}
