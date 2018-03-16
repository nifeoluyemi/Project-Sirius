using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class EntityBaseConfig<T> : EntityTypeConfiguration<T> where T : class
    {
        public EntityBaseConfig()
        {

        }
    }
}
