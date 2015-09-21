using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anvil.Common.DataContext;

namespace AA.Containers
{
    public class AAAreaRepository : GenericRepository<AAArea>
    {
        public AAAreaRepository()
            :base(new AA.DataContext.AADatabase())
        { }
    }
}
