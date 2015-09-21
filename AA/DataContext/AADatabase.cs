using System;

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

using System.Collections.Generic;

using Anvil.Common.Seeding;
using AA.Authentication;
using AA.Containers;
using AA.Meetings;


namespace AA.DataContext
{
    public class AADatabase : IdentityDbContext<AAAccount>, ISeedableObject
    {
        public AADatabase()
            : base("AA", throwIfV1Schema: false)
        {
        }

        public static AADatabase Create()
        {
            return new AADatabase();
        }


        public DbSet<AAArea> Areas { get; set; }

        public DbSet<AADistrict> Districts { get; set; }

        public DbSet<AAGroup> Groups { get; set; }

        public DbSet<AAMeeting> Meetings { get; set; }

        public DbSet<AAMeetingType> MeetingTypes { get; set; }

        public DbSet<ContactInfo.ContactAddress> ContactAddresses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AAMeeting>()
                .HasMany(m => m.MeetingTypes)
                .WithMany(t => t.Meetings)
                .Map(mt =>
                {
                    mt.MapLeftKey("AAMeetingKey");
                    mt.MapRightKey("AAMeetingTypeKey");
                    mt.ToTable("AAMeetingTypeLink", "AA.Meetings");
                });

            modelBuilder.Entity<ContactInfo.ContactAddress>()
                .HasOptional(a => a.Meeting)
                .WithRequired(s => s.MeetingAddress);


            base.OnModelCreating(modelBuilder);

            /*
            this.HasKey(c => c.Id);
        this.Property(c => c.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        this.HasRequired(c1 => c1.Class2).WithRequiredPrincipal(c2 => c2.Class1);

             * * */

            modelBuilder.Entity<AAMeeting>()
                .HasKey(m => m.AAMeetingKey);
            modelBuilder.Entity<AAMeeting>()
                .HasRequired(a => a.MeetingAddress)
                .WithOptional(m => m.Meeting);

        }



        public void SeedDefaultObjects()
        {
            SeedRepo(new AAAccountManager());

            SeedRepo(new ContactInfo.ContactAddressRepository());

            SeedRepo(new AAAreaRepository());

            SeedRepo(new AADistrictRepository());
            
            SeedRepo(new AAGroupRepository());
            
            SeedRepo(new AAMeetingTypeRepository());
            

            AAMeetingRepository mRepo = new AAMeetingRepository();
            SeedRepo(mRepo);

            mRepo.AddMeetingType(AAMeeting.DrakesBranchFriday, AAMeetingType.OpenDiscussion);
            mRepo.AddMeetingType(AAMeeting.DrakesBranchFriday, AAMeetingType.Handicap);

            mRepo.AddMeetingType(AAMeeting.KeysvilleReflectionTuesday, AAMeetingType.OpenDiscussion);
            mRepo.AddMeetingType(AAMeeting.KeysvilleReflectionTuesday, AAMeetingType.Handicap);

            mRepo.AddMeetingType(AAMeeting.WomensGroupFriday, AAMeetingType.OpenDiscussion);
            mRepo.AddMeetingType(AAMeeting.WomensGroupFriday, AAMeetingType.Handicap);
            mRepo.AddMeetingType(AAMeeting.WomensGroupFriday, AAMeetingType.Womens);

        }

        private void SeedRepo(ISeedableObject repo)
        {
            try
            {
                repo.SeedDefaultObjects();
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Error seeding repo {0}", repo.GetType().Name), ex);
            }
        }
    }
}