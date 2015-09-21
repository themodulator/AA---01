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



namespace AA.Security
{
    [Table("AAPermission", Schema = "AA.Security")]
    public class AAPermission
    {
        [Key]
        public Guid AAPermissionKey { get; set; }

        public AAPermissionScope Scope { get; set;}

        public AAPermissionLevel Level { get; set; }

        public Guid? AreaId { get; set; }

        public Guid? DistrictId { get; set; }

        public Guid? GroupId { get; set; }

        public string MemberId { get; set; }
    }
}
