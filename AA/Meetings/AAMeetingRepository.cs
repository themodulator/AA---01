using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Reflection;

using AA.DataContext;
using Anvil.Common.DataContext;

namespace AA.Meetings
{
    public class AAMeetingRepository : GenericRepository<AAMeeting>
    {
        public AAMeetingRepository()
            :base(new AADatabase())
        { }


        #region Get

        public AAMeeting[] GetMeetings(int areaId, int districtId, DayOfWeek weekDay)
        {

            return Get(x => x.WeekDay == weekDay &
                x.District.DistrictId == districtId
                & x.Area.AreaId == areaId)
                .OrderBy( x=> x.StartTime)
                .ToArray();
        }

        #endregion


        #region Meeting Types

        public void AddMeetingType(AAMeeting m, AAMeetingType t)
        {
            AddMeetingType(m.AAMeetingKey, t.AAMeetingTypeKey);
        }

        public void AddMeetingType(Guid meetingKey, Guid meetingTypeKey)
        {
            AADatabase db = (AADatabase)this.Context;
            AAMeeting m = db.Meetings.First(x => x.AAMeetingKey.Equals(meetingKey));

            AAMeetingType mt = db.MeetingTypes.First(x => x.AAMeetingTypeKey.Equals(meetingTypeKey));

            if(!m.MeetingTypes.Contains(mt))
            {
                m.MeetingTypes.Add(mt);
                db.SaveChanges();
            }

        }

        #endregion

        #region Addresses

        public void SetAddress(Guid meetingKey, AA.ContactInfo.ContactAddress address)
        {
            AADatabase db = (AADatabase)this.Context;
            AAMeeting m = db.Meetings.First(x => x.AAMeetingKey.Equals(meetingKey));
            if(m.MeetingAddress != null)
            {
                
            }

        }

        #endregion
    }
}
