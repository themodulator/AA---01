using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Linq.Dynamic;

using Anvil.Common.DataContext;


namespace AA.Containers
{
    public class AADistrictRepository : GenericRepository<AA.Containers.AADistrict>
    {
        public AADistrictRepository()
            : base(new AA.DataContext.AADatabase())
        { }


        public override void SeedDefaultObjects()
        {
            base.SeedDefaultObjects();
        }
        
    }

}
