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

using AA.Authentication;

using Anvil.Common.Seeding;
using AA.Meetings;

namespace AA.Containers
{
    [Table("AAArea", Schema = "AA.Containers")]
    public class AAArea
    {
        [Key]
        public Guid AreaKey { get; set; }

        [Display(Name = "ID")]
        [Index("IX_Area_ID", IsUnique = true)]
        [Range(1, int.MaxValue, ErrorMessage = "The Area ID is a required value and must be an integer value greater than 0")]
        public int AreaId { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AADistrict> Districts { get; set; }

        public virtual ICollection<AAGroup> Groups { get; set; }

        public virtual ICollection<AAMeeting> Meetings { get; set; }

        
        // ---------- Default Items
        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAArea Area71
        {
            get
            {
                return new AAArea()
                {
                    AreaId = 71,
                    AreaKey = new Guid("6439DF2D-F921-46E0-89AC-8C392BDA1494"),
                    Title = "Virginia"
                };
            }
        }
    }
}
