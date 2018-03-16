using Sirius.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class AuditConfig : ComplexTypeConfiguration<Audit>
    {
        public AuditConfig()
        {
            this.Property(a => a.CreatedBy).IsOptional().HasColumnName("CreatedBy");
            this.Property(a => a.CreatedDate).IsOptional().HasColumnName("CreatedDate");
            this.Property(a => a.ModifiedBy).IsOptional().HasColumnName("ModifiedBy");
            this.Property(a => a.ModifiedDate).IsOptional().HasColumnName("ModifiedDate");
            this.Property(a => a.RecordState).IsRequired().HasColumnName("RecordState");
        }
    }
}
