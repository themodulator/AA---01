using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AA.Containers;
using AA.Meetings;

using Anvil.Common.Seeding;

namespace AA.ContactInfo
{
    [Table("Address", Schema = "AA.ContactInfo")]
    public class ContactAddress
    {
        [Key]
        public Guid AddressKey { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "The address line cannot exceede 128 characters")]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(128, ErrorMessage = "The city name cannot exceede 128 characters")]
        public string City { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "The state code cannot exceede 2 characters")]
        public string State { get; set; }

        [Required]
        [MaxLength(5, ErrorMessage = "The zip code cannot exceede 5 characters")]
        public string Zip { get; set; }

        public bool Primary { get; set; }

        public virtual AAMeeting Meeting { get; set; }

        /*
        [ForeignKey("District")]
        [Required]
        public Guid? DistrictKey { get; set; }

        public virtual AADistrict District { get; set; }

        [ForeignKey("Group")]
        [Required]
        public Guid? GroupKey { get; set; }

        public virtual AAGroup Group { get; set; }

       
    */

        [NotMapped]
        [Seedable]
        public static ContactAddress DrakesBranchBaptistChurch
        {
            get
            {
                return new ContactAddress()
                {
                    AddressKey = AAMeeting.DrakesBranchFriday.AAMeetingKey,
                    Title = "Drakes Branch Baptist Church",
                    Address = "4525 Main St",
                    City = "Drakes Branch",
                    State = "VA",
                    Zip = "23937",
                    Primary = true
                };
            }
        }

        [NotMapped]
        [Seedable]
        public static ContactAddress BrieryPresbyterianChurch
        {
            get
            {
                return new ContactAddress()
                {
                    AddressKey = AAMeeting.KeysvilleReflectionTuesday.AAMeetingKey,
                    Title = "Briery Presbyterian Church",
                    Address = "181 Briery Church Rd",
                    City = "Keysville",
                    State = "VA",
                    Zip = "23947",
                    Primary = true
                };
            }
        }


                [NotMapped]
        [Seedable]
        public static ContactAddress FarmvilleVASAP
        {
            get
            {
                return new ContactAddress()
                {
                    AddressKey = AAMeeting.WomensGroupFriday.AAMeetingKey,
                    Title = "VASAP",
                    Address = "4026 W Third St",
                    City = "Farmville",
                    State = "VA",
                    Zip = "23901",
                    Primary = true
                };
            }
        }
    }
}
