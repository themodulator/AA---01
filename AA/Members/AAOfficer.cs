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

using AA.Containers;


namespace AA.Members
{
    [Table("AAOfficer", Schema = "AA.Members")]
    public class AAOfficer
    {
        [Key]
        public Guid AAOfficerKey { get; set; }

        [Required]
        [MinLength(128)]
        public string Title { get; set; }

        [ForeignKey("Area")]
        public Guid? AreaKey { get; set; }

        public virtual AAArea Area { get; set; }

        [ForeignKey("District")]
        public Guid? DistrictKey { get; set; }

        public virtual AADistrict District { get; set; }

        [ForeignKey("Group")]
        public Guid? GroupKey { get; set; }

        public virtual AAGroup Group { get; set; }

        [ForeignKey("Member")]
        public Guid MemberKey { get; set; }

        public virtual AAMember Member { get; set; }

        [ForeignKey("Committee")]
        public Guid CommitteeKey { get; set; }

        public virtual AACommittee Committee { get; set; }
    }
}
