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
using Anvil.Common.DataContext;

using Anvil.Common.Seeding;

namespace AA.ContactInfo
{
    public class ContactAddressRepository : GenericRepository<ContactAddress>
    {
        public ContactAddressRepository()
            :base(new AADatabase())
        {}


        

    }
}
