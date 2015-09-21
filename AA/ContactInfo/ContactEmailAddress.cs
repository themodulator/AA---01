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
using AA.Members;

namespace AA.ContactInfo
{
    [Table("ContactEmailAddress", Schema = "AA.ContactInfo")]
    public class ContactEmailAddress
    {
        [Key]
        public Guid ContactEmailAddressKey { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        public bool Primary { get; set; }

        public ContactEmailAddressType Type { get; set; }

        [ForeignKey("District")]
        public Guid? DistrictKey { get; set; }

        public virtual AADistrict District { get; set; }

        [ForeignKey("Group")]
        public Guid? GroupKey { get; set; }

        public virtual AAGroup Group { get; set; }

        [ForeignKey("Member")]
        public Guid? MemberKey { get; set; }

        public virtual AAMember Member { get; set; }
    }
}
