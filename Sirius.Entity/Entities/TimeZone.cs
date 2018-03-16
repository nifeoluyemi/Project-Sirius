using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Timezone : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Abbreivation { get; set; }

        //public TimeZoneInfo TimeZoneInfo { get; set; }
        //get timezonename in nuget
    }
}
