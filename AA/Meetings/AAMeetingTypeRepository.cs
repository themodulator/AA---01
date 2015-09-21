using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Reflection;

using AA.DataContext;
using Anvil.Common.Seeding;
using Anvil.Common.DataContext;

namespace AA.Meetings
{
    public class AAMeetingTypeRepository : GenericRepository<AAMeetingType>, ISeedableObject
    {
        public AAMeetingTypeRepository()
            :base(new AADatabase())
        {}


    }
}
