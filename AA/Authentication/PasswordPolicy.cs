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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.IO;
using System.Reflection;

using Anvil.Common.Seeding;

namespace AA.Authentication
{
    [Table("PasswordPolicy", Schema = "AA.Authentication")]
    public class PasswordPolicy 
    {
        [Key]
        public Guid PasswordPolicyKey { get; set; }

        [Required]
        [MaxLength(128)]
        [Index("IX_Password_Title", IsUnique=true)]
        public string Title { get; set; }

        public bool IsDefault { get; set; }

        public int RequiredLength { get; set; }

        public bool RequireNonLetterOrDigit { get; set; }

        public bool RequireDigit { get; set; }

        public bool RequireLowercase { get; set; }

        public bool RequireUppercase { get; set; }

        [Seedable(Overwrite = false)]
        [NotMapped]
        public static PasswordPolicy InitialPasswordPolicy
        {
            get
            {
                return new PasswordPolicy()
                {
                    PasswordPolicyKey = new Guid("E3CE1CA1-4096-40FD-A027-A992608277FA"),
                    Title = "Initial Policy",
                    IsDefault = true,
                    RequiredLength = 7,
                    RequireLowercase = true,
                    RequireDigit = true,
                    RequireUppercase= true,
                    RequireNonLetterOrDigit = true
                };
            }
        }
    }
}
