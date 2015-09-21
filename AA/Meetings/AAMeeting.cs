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
using Anvil.Common.Seeding;

namespace AA.Meetings
{
    [Table("AAMeeting", Schema = "AA.Meetings")]
    public class AAMeeting
    {
        [Key]
        public Guid AAMeetingKey { get; set; }

        public DayOfWeek WeekDay { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        public bool Active { get; set; }

        public string Comment { get; set; }

        [ForeignKey("Area")]
        public Guid? AreaKey { get; set; }

        public virtual AAArea Area { get; set; }

        [ForeignKey("District")]
        public Guid? DistrictKey { get; set; }

        public virtual AADistrict District { get; set; }

        [ForeignKey("Group")]
        [Required]
        public Guid GroupKey { get; set; }

        public virtual AAGroup Group { get; set; }

        public virtual List<AAMeetingType> MeetingTypes { get; set; }

        public virtual ContactInfo.ContactAddress MeetingAddress { get; set; }


        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAMeeting DrakesBranchFriday
        {
            get
            {
                AAMeeting m = new AAMeeting()
                {
                    AAMeetingKey = new Guid("8E490BDD-DB12-4017-B331-A67E869DB56B"),
                    Active = true,
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    GroupKey = AAGroup.DrakesBranch.AAGroupKey,
                    StartTime = new DateTime(2015, 9, 19, 20, 0, 0, 0),
                    WeekDay = DayOfWeek.Friday,
                };

                return m;
            }
        }

        [NotMapped]
        [Seedable]
        public static AAMeeting KeysvilleReflectionTuesday
        {
            get
            {


                AAMeeting m = new AAMeeting()
                {
                    AAMeetingKey = new Guid("CC46433B-D86C-42DD-B2C1-6BF8290A3AEC"),
                    Active = true,
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    GroupKey = AAGroup.KeysvilleReflections.AAGroupKey,
                    StartTime = new DateTime(2015, 9, 19, 19, 0, 0, 0),
                    WeekDay = DayOfWeek.Tuesday
                };

                return m;
            }
        }


        [NotMapped]
        [Seedable]
        public static AAMeeting WomensGroupFriday
        {
            get
            {


                AAMeeting m = new AAMeeting()
                {
                    AAMeetingKey = new Guid("502FED83-DA36-4C19-A43D-386A19952377"),
                    Active = true,
                    AreaKey = AAArea.Area71.AreaKey,
                    DistrictKey = AADistrict.District36.DistrictKey,
                    GroupKey = AAGroup.WomensGroup.AAGroupKey,
                    StartTime = new DateTime(2015, 9, 19, 18, 15, 0, 0),
                    WeekDay = DayOfWeek.Friday
                };

                return m;
            }
        }

    }
}
