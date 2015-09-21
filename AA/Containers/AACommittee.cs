using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace AA.Containers
{
    [Table("AACommittee", Schema = "AA.Containers")]
    public class AACommittee
    {
        [Key]
        public Guid AACommitteeKey { get; set; }

        public Guid ContainerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
    }
}
