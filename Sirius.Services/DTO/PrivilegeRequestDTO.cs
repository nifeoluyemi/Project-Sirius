using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using Sirius.Services.Manager.StaticManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.DTO
{
    public class PrivilegeRequestDTO
    {
        public Guid PrivilegeRequestId { get; set; }
        public string UserId { get; set; }
        public string UserFullname { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
        public string RequestDate { get; set; }


        public static PrivilegeRequestDTO Map(PrivilegeRequestBO privilegeRequest, IZeus zeus)
        {
            PrivilegeRequestDTO self = new PrivilegeRequestDTO
            {
                PrivilegeRequestId = privilegeRequest.Id,
                UserId = privilegeRequest.UserId,
                Role = privilegeRequest.RoleName,
                RequestDate = DateExtension.ConvertDateToShort(privilegeRequest.RequestDate)
            };
            return self;
        }

        public static IEnumerable<PrivilegeRequestDTO> Map(IEnumerable<PrivilegeRequestBO> privilegeRequests, IZeus zeus)
        {
            List<PrivilegeRequestDTO> selfs = new List<PrivilegeRequestDTO>();
            foreach (PrivilegeRequestBO privilegeRequest in privilegeRequests)
            {
                PrivilegeRequestDTO contest = PrivilegeRequestDTO.Map(privilegeRequest, zeus);
                selfs.Add(contest);
            }
            return selfs.AsEnumerable();
        }
    }
}
