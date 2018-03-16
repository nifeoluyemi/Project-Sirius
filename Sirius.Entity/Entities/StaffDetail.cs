using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class StaffDetail
    {
        public int ID { get; set; }
        public string StaffID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Supervisor { get; set; }
        public string SupervisorID { get; set; }
        public string JobDescription { get; set; }
        public Guid OrganizationID { get; set; }
    }
}
