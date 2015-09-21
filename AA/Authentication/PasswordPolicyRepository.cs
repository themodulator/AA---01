using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Anvil.Common.DataContext;

using AA.DataContext;

namespace AA.Authentication
{
    public class PasswordPolicyRepository : GenericRepository<PasswordPolicy>
    {
        public PasswordPolicyRepository()
            : base(new AADatabase())
        { }


        #region Get

        public PasswordPolicy GetDefault()
        {
            return First(x => x.IsDefault);
        }

        #endregion

        #region Insert

        public override void Insert(PasswordPolicy entity)
        {
            if(entity.IsDefault)
                RemoveDefault();

            base.Insert(entity);
        }

        #endregion

        #region Update

        public void SetDefault(Guid id)
        {
            PasswordPolicy p = First(x => x.IsDefault);
            if(p != null)
            {
                RemoveDefault();
                Update(p);
            }
        }

        public override void Update(PasswordPolicy entityToUpdate)
        {
            if (entityToUpdate.IsDefault)
                RemoveDefault();

            base.Update(entityToUpdate);
        }

        private void RemoveDefault()
        {
            PasswordPolicy[] pp = Get(x => x.IsDefault).ToArray();
            foreach(PasswordPolicy p in pp)
            {
                p.IsDefault = false;
                Update(p);
            }
        }


        #endregion
    }
}
