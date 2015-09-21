using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AA.DataContext;
using Anvil.Common.Seeding;

using System.Reflection;

namespace AA.Authentication
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class AAAccountManager : UserManager<AAAccount>, Anvil.Common.Seeding.ISeedableObject
    {
        public AAAccountManager()
            :base (new UserStore<AAAccount>(new AADatabase()))
        { }

        public AAAccountManager(IUserStore<AAAccount> store)
            : base(store)
        {
        }

        public static AAAccountManager Create(IdentityFactoryOptions<AAAccountManager> options, IOwinContext context) 
        {
            var manager = new AAAccountManager(new UserStore<AAAccount>(context.Get<AADatabase>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AAAccount>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords



            /*
             * PasswordPolicy p = (new PasswordPolicyRepository().GetDefault());
                manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = p.RequiredLength,
                RequireNonLetterOrDigit = p.RequireNonLetterOrDigit,
                RequireDigit = p.RequireDigit,
                RequireLowercase = p.RequireLowercase,
                RequireUppercase = p.RequireUppercase,
            };
             */

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };



            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<AAAccount>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<AAAccount>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<AAAccount>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public void SeedDefaultObjects()
        {
            AAAccountManager mgr = new AAAccountManager();
            if(mgr.FindByName(AAAccount.DefaultAdmin.UserName) == null)
            {
                mgr.Create(AAAccount.DefaultAdmin, "B1ll&B0b");
            }

            

            
            AARoleManager rMgr = new AARoleManager();

            Type t = typeof(IdentityRole);

            PropertyInfo[] pp = rMgr.GetType().GetProperties()
                .Where(p => p.PropertyType == t &
                    Attribute.IsDefined(p, typeof(SeedableAttribute))).ToArray();


            foreach (PropertyInfo p in pp)
            {
                SeedableAttribute a = (SeedableAttribute)p.GetCustomAttribute(typeof(SeedableAttribute));

                object m = rMgr.GetType().GetProperty(p.Name, BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

                IdentityRole r = (IdentityRole)p.GetValue(m, null);

                if (rMgr.RoleExists(r.Name))
                    rMgr.Create(r);
            }
        }
    }

    public class AARoleManager : RoleManager<IdentityRole>
    {
        public AARoleManager()
            :base(new RoleStore<IdentityRole>(new AADatabase()))
        { }

        [Seedable]
        [NotMapped]
        public static IdentityRole AdminRole
        {
            get
            {
                return new IdentityRole()
                {
                    Id = "8E8DC719-0333-4537-BF80-C9D92A94ABB5",
                    Name = "Administrators"
                };
            }
        }

        [Seedable]
        [NotMapped]
        public static IdentityRole SecurityAdmins
        {
            get
            {
                return new IdentityRole()
                {
                    Id = "A3F339D1-4285-4240-AF74-514AB9F4BAAE",
                    Name = "Security Managers"
                };
            }
        }

        [Seedable]
        [NotMapped]
        public static IdentityRole AreaAdmins
        {
            get
            {
                return new IdentityRole()
                {
                    Id = "53722F44-E3C0-4024-9678-8D3F7AA75B5A",
                    Name = "Area Admins"
                };
            }
        }

        [Seedable]
        [NotMapped]
        public static IdentityRole DistrictAdmins
        {
            get
            {
                return new IdentityRole()
                {
                    Id = "4ABAB782-B4AA-46E9-8137-D88E07D69C39",
                    Name = "District Admins"
                };
            }
        }

        [Seedable]
        [NotMapped]
        public static IdentityRole GroupAdmins
        {
            get
            {
                return new IdentityRole()
                {
                    Id = "4ABAB782-B4AA-46E9-8137-D88E07D69C39",
                    Name = "Group Admins"
                };
            }
        }



    }

    // Configure the application sign-in manager which is used in this application.
    public class AASignInManager : SignInManager<AAAccount, string>
    {
        public AASignInManager(AAAccountManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AAAccount user)
        {
            return user.GenerateUserIdentityAsync((AAAccountManager)UserManager);
        }

        public static AASignInManager Create(IdentityFactoryOptions<AASignInManager> options, IOwinContext context)
        {
            return new AASignInManager(context.GetUserManager<AAAccountManager>(), context.Authentication);
        }
    }
}
