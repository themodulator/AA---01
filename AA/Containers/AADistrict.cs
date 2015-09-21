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


using System.Reflection;

using AA.Authentication;
using Anvil.Common.Seeding;
using AA.Meetings;

namespace AA.Containers
{
    [Table("AADistrict", Schema = "AA.Containers")]
    public class AADistrict
    {
        [Key]
        public Guid DistrictKey { get; set; }

        [ForeignKey("Area")]
        [Required]
        public Guid AreaKey { get; set; }

        public virtual AAArea Area { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The District ID is a required value and must be an integer value greater than 0")]
        public int DistrictId { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        [Required]
        public string CssTheme { get; set; }

        public ICollection<AAGroup> Groups { get; set; }

        public virtual ICollection<AAMeeting> Meetings { get; set; }


        // ---------- Default Items

        [Seedable(Overwrite = true)]
        [NotMapped]
        public static AADistrict District36
        {
            get
            {
                return new AADistrict()
                {
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictId = 36,
                    DistrictKey = new Guid("23118192-7687-414C-A836-5B12496D58EB"),
                    CssTheme = "yeti.css",
                    Title = "District 36"
                };
            }
        }

    }
}
