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
    public class UserDTO
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string AbbreviatedName { get; set; }
        public string StaffId { get; set; }
        public string JobDescription { get; set; }
        public string SupervisorId { get; set; }
        public string SupervisorFullName { get; set; }
        public string Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentShortname { get; set; }
        public Guid OrganizationId { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
        public string Roles { get; set; }
        public Guid StatusId { get; set; }
        public string Status { get; set; }
        public string StatusShortName { get; set; }

        // Number of tasks
        #region Mini - Mapping
        
        public static UserDTO MapChild(UserBO user)
        {
            UserDTO self = new UserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.StaffUserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
                AbbreviatedName = user.FirstName + " " + user.LastName.ToUpper()[0] + "."
            };
            return self;
        }

        public static IEnumerable<UserDTO> MapChild(IEnumerable<UserBO> users)
        {
            IList<UserDTO> selfs = new List<UserDTO>();
            foreach (UserBO user in users)
            {
                UserDTO self = MapChild(user);
                selfs.Add(self);
            }
            return selfs;
        }

        #endregion

        public static UserDTO Map(UserBO user, IZeus zeus)
        {
            UserDTO self = new UserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.StaffUserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                FullName = user.FirstName + " " + user.LastName,
                JobDescription = user.JobDescription,
            };

            self.OrganizationId = user.OrganizationId;
            self.Roles = StringConversion.ConvertToString(self.UserRoles);

            return self;
        }

        public static IEnumerable<UserDTO> Map(IEnumerable<UserBO> users, IZeus zeus)
        {
            IList<UserDTO> selfs = new List<UserDTO>();
            foreach (UserBO user in users)
            {
                UserDTO self = Map(user, zeus);
                selfs.Add(self);
            }
            return selfs;
        }

        public static async Task<UserDTO> MapAsync(UserBO user, IZeus zeus)
        {
            UserDTO self = new UserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.StaffUserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + " " + user.LastName,
            };


            return self;
        }

        public static async Task<IEnumerable<UserDTO>> MapAsync(IEnumerable<UserBO> users, IZeus zeus)
        {
            IList<UserDTO> selfs = new List<UserDTO>();
            foreach (UserBO user in users)
            {
                UserDTO self = await MapAsync(user, zeus);
                selfs.Add(self);
            }
            return selfs;
        }
    }
}
