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
    [Table("CalendarEvent", Schema = "AA.ContentElements")]
    public class CalendarEvent
    {
        [Key]
        public Guid CalendarEventKey { get; set; }

        [Display(Name = "Presentaion Date", Description = "This is the date/time the event will begin being displayed on the web")]
        public DateTime PresentationDate { get; set; }

        [Display(Name = "ExpirationDate Date", Description = "This is the date/time when the event will stop being displayed on the web")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Start Date", Description = "This is the date/time when the event will take place")]
        public DateTime EventStartsOn { get; set; }

        [Display(Name = "End Date", Description = "This is the date/time when the event will have completed")]
        public DateTime EventEndOn { get; set; }

        [Display(Name = "All Day Event", Description = "This event takes place for the entire day")]
        public bool IsAllDay { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Comment { get; set; }

        public ElementAudience Audience { get; set; }
    }
}
