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

using AA.ContactInfo;
using AA.Containers;

namespace AA.Members
{
    [Table("AAMember", Schema = "AA.Members")]
    public class AAMember
    {
        [Key]
        public Guid AAMemberKey { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(1, ErrorMessage = "The last name must at least be one character")]
        [MaxLength(128)]
        public string Surname { get; set;}

        [Display(Name = "First Name")]
        [Required]
        [MinLength(1, ErrorMessage = "Please include a valid first name")]
        [MaxLength(128)]
        public string GivenName { get; set; }

        [Display(Name = "Sobriety Date")]
        public DateTime SobrietyDate { get; set; }

        [Display(Name = "Contact Method")]
        public ContactMethodTypes ContactMethod { get; set; }

        public virtual ICollection<ContactAddress> PostalAddresses { get; set; }

        public virtual ICollection<ContactEmailAddress> EmailAddresses { get; set; }

        public virtual AAGroup Group { get; set; }

        public virtual ICollection<AACommittee> Committees { get; set; }

        public virtual ICollection<AAOfficer> OfficerPositions { get; set; }
}
}
