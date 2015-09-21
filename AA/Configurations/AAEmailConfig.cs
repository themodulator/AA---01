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

namespace AA.Configurations
{
    [Table("AAEmailConfig", Schema = "AA.Configurations")]
    public class AAEmailConfig
    {
        [Key]
        public Guid AAEmailConfigKey { get; set; }

        [ForeignKey("Area")]
        public Guid? AreaKey { get; set; }

        public AAArea Area { get; set; }

        [ForeignKey("District")]
        public Guid? DistrictKey { get; set; }

        public AADistrict District { get; set; }

        [ForeignKey("Group")]
        public Guid? GroupKey { get; set; }

        public AAGroup Group { get; set; }

        public string Host { get; set; }

        public bool UseSSL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }
    }
}
