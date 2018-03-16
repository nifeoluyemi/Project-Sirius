using Sirius.Data.Context;
using Sirius.Data.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.UnitofWork.Concrete
{
    public class UnitofWork : IUnitofWork 
    {
        private readonly IDbFactory dbFactory;
        private SiriusContext dbContext;

        public UnitofWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public SiriusContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

        public async Task CommitAsync()
        {
            await DbContext.CommitAsync();
        }
    }
}
