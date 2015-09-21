using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using AA.Authentication;
using AA.Containers;

namespace AA.Members
{
    [Table("AAAreaAssignment", Schema = "AA.Members")]
    public class AAAreaAssignment
    {
        [Key]
        public Guid AAAreaAssignmentKey { get; set; }

        public Guid AreaKey { get; set; }

        public string AccountId { get; set; }

        public virtual ICollection<AAAccount> Accounts { get; set; }

        public virtual ICollection<AAArea> Area { get; set; }
    }
}
