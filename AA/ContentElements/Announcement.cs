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



namespace AA.ContentElements
{
    [Table("Announcement", Schema = "AA.ContentElements")]
    public class Announcement
    {
        [Key]
        public Guid AnnouncementKey { get; set; }

        [Display(Name = "Presentation Date", Description = "This is the date/time the notice will begin being displayed on the web")]
        public DateTime PresentationDate { get; set; }

        [Display(Name = "Expiration Date", Description = "This is the date/time when the notice will stop being displayed on the web")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        public string Article { get; set; }
    }
}
