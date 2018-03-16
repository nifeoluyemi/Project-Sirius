using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Audit
    {
        public void Initialize()
        {
            this.CreatedDate = this.ModifiedDate = DateTime.UtcNow;
            this.RecordState = RecordStateType.Active;
        }

        public Audit()
        {
            Initialize();
        }

        public Audit(string userId)
        {
            this.CreatedBy = this.ModifiedBy = userId;
            Initialize();
        }

        public Audit ModifyState(string userId)
        {
            Audit self = this;
            self.ModifiedBy = userId;
            self.ModifiedDate = DateTime.UtcNow;
            return self;
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public RecordStateType RecordState { get; set; }
    }
}
