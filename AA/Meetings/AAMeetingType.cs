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

namespace AA.Meetings
{
    [Table("AAMeetingType", Schema = "AA.Meetings")]
    public class AAMeetingType
    {
        [Key]
        public Guid AAMeetingTypeKey { get; set; }

        public string Description { get; set; }

        public string MeetingTypeId { get; set; }

        public string Caption { get; set; }

        public string IconCss { get; set; }

        public virtual ICollection<AAMeeting> Meetings { get; set; }


        [NotMapped]
        [Seedable]
        public static AAMeetingType OpenDiscussion
        {
            get
            {
                return new AAMeetingType()
                {
                    AAMeetingTypeKey = new Guid("7B63910D-5DF3-4E76-886C-A507BE1E3B2E"),
                    Caption = "Open Disucussion",
                    Description = "Open discussion meetings are open for the public to observe and participate",
                    IconCss = "fa fa-comments-o",
                    MeetingTypeId = "O"
                };
            }
        }

        [NotMapped]
        [Seedable]
        public static AAMeetingType Handicap
        {
            get
            {
                return new AAMeetingType()
                {
                    AAMeetingTypeKey = new Guid("2C847069-D243-4DAC-BC10-AC00F0A4A45C"),
                    Caption = "Handicap Accessible",
                    Description = "The wheelchair icon indicates the meeting place is hanicap accessible",
                    IconCss = "fa fa-wheelchair",
                    MeetingTypeId = "HC"
                };
            }
        }

        [NotMapped]
        [Seedable]
        public static AAMeetingType Womens
        {
            get
            {
                return new AAMeetingType()
                {
                    AAMeetingTypeKey = new Guid("D18C5CF6-9885-4651-B051-E0465BA65BDA"),
                    Caption = "Women's Meeting",
                    Description = "Women's meetings focus on female issues concerning alcoholism",
                    IconCss = "fa fa-female",
                    MeetingTypeId = "W"
                };
            }
        }
    }
}
