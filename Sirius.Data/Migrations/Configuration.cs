using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading.Tasks;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.IdentityServices.Store;
using Sirius.Data.BusinessObject;
using Sirius.Data.Repository.Concrete;

namespace Sirius.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<SiriusContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Sirius.Data.Context.SiriusContext";
        }

        protected override void Seed(SiriusContext context)
        {
            Sirius.Data.Repository.DataSource db = new Sirius.Data.Repository.DataSource();

            OrganizationBO org = db.organizationRepository.FindBy(o => o.ShortName.ToLower() == "geekcamp").FirstOrDefault();
            if (org == null)
            {
                org = new OrganizationBO
                {
                    Name = "GeekCamp Studios",
                    ShortName = "geekcamp",
                    Status = Entity.Enums.Status.ACTIVE,
                    Audit = new Entity.Entities.Audit()
                };
                db.organizationRepository.Add(org);
                db.unitofWork.Commit();
            }


            var userManager = new SiriusUserManager(new SiriusUserStore(context));
            var roleManager = new SiriusRoleManager(new SiriusRoleStore(context));

            //System.Web.HttpContext.Current.GetOwinContext().

            const string name = "gadmin@siriuspm.com";
            const string password = "geekcamp1";

            string[] roles = { "GlobalAdmin", "Supervisor", "Staff", "OrganizationAdmin" };

            foreach (string rolename in roles)
            {
                var role = roleManager.FindByName(rolename);
                if (role == null)
                {
                    role = new RoleBO(rolename);
                    var roleresult = roleManager.Create(role);
                }
            }

            var role1 = roleManager.FindByName(roles[0]);
            //var role2 = roleManager.FindByName(roles[6]);

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new UserBO 
                { 
                    OrganizationId = org.Id, 
                    UserName = name, 
                    Email = name, 
                    FirstName = "GeekCamp",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    Audit = new Entity.Entities.Audit(),
                    StaffUserName = "GlobalAdmin",
                    DateOfBirth = DateTime.UtcNow,
                    HasAcceptedTerms = true,
                    Gender = Entity.Enums.Gender.Male
                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role1.Name))
            {
                var result = userManager.AddToRole(user.Id, role1.Name);
            }
            //if (!rolesForUser.Contains(role2.Name))
            //{
            //    var result = userManager.AddToRole(user.Id, role2.Name);
            //}

        }
    }
}
