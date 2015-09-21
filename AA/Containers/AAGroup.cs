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

using Anvil.Common.Seeding;

using AA.Authentication;

using AA.Meetings;

namespace AA.Containers
{
    [Table("AAGroup", Schema = "AA.Containers")]
    public class AAGroup
    {
        [Key]
        public Guid AAGroupKey { get; set; }

        [ForeignKey("Area")]
        public Guid? AreaKey { get; set; }

        public virtual AAArea Area { get; set; }

        [ForeignKey("District")]
        [Required]
        public Guid DistrictKey { get; set; }

        public virtual AADistrict District { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AAMeeting> Meetings { get; set; }

        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAGroup DrakesBranch
        {
            get
            {
                return new AAGroup()
                {
                    AAGroupKey = new Guid("75E81169-A482-4E22-87DD-4C99F10FEC2B"),
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    Title = "Drakes Branch Serenity Group",
                    Active = true
                };
            }
        }

        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAGroup KeysvilleReflections
        {
            get
            {
                return new AAGroup()
                {
                    AAGroupKey = new Guid("DE490A34-9B71-4C6A-95F8-B2F9648FCAB9"),
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    Title = "Keysville Reflections",
                    Active = true
                };
            }
        }

        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAGroup WomensGroup
        {
            get
            {
                return new AAGroup()
                {
                    AAGroupKey = new Guid("17D8C519-56A2-44FE-BFCE-9F0280462CE2"),
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    Title = "Women's Group",
                    Active = true
                };
            }
        }
    }
}
