using Sirius.Persistence.Context;
using Sirius.Persistence.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.UnitofWork.Concrete
{
    public class DbFactory : Disposable, IDbFactory
    {
        SiriusContext dbContext;

        public SiriusContext Init()
        {
            return dbContext ?? (dbContext = new SiriusContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
