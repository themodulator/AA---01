using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Anvil.Common.Seeding;

namespace AA.Authentication
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AAAccount : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AAAccount> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [NotMapped]
        [Seedable(Overwrite = true)]
        public static AAAccount DefaultAdmin
        {
            get
            {

                return new AAAccount()
                {
                    Id = "20FF5FC6-D909-4C41-AB8E-06C88EE4F0E2",
                    Email = "admin@aamanager.com",
                    UserName = "admin"
                };
            }
        }
    }


}