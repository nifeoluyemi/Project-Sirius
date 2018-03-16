namespace Sirius.Persistence.Migrations
{
    using Microsoft.Owin.Host.SystemWeb;
    using Sirius.Persistence.Context;
    using Sirius.Persistence.IdentityServices.Managers;
    using Sirius.Persistence.IdentityServices.Store;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Owin;
    using Microsoft.Owin;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Sirius.Persistence.BusinessObject;

    public sealed class Configuration : DbMigrationsConfiguration<Sirius.Persistence.Context.SiriusContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Sirius.Persistence.Context.SiriusContext";
        }

        protected override void Seed(Sirius.Persistence.Context.SiriusContext context)
        {
            var userManager = new SiriusUserManager(new SiriusUserStore(new SiriusContext()));
            var roleManager = new SiriusRoleManager(new SiriusRoleStore(new SiriusContext()));

            //System.Web.HttpContext.Current.GetOwinContext().

            const string name = "gadmin@siriuspm.com";
            const string password = "geekcamp1";
            
            string[] roles = { "GlobalAdmin", "Admin", "ITAdmin", "PMAdmin", "Supervisor", "Staff" };

            foreach(string rolename in roles)
            {
                var role = roleManager.FindByName(rolename);
                if (role == null)
                {
                    role = new RoleBO(rolename);
                    var roleresult = roleManager.Create(role);
                }
            }

            var role1 = roleManager.FindByName(roles[0]);
            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new UserBO { UserName = name, Email = name, EmailConfirmed = true, LockoutEnabled = false, Audit = new Entity.Entities.Audit(), StaffUserName = "GlobalAdmin", DateOfBirth = DateTime.UtcNow, Gender = Entity.Enums.Gender.Male };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
           
            if (!rolesForUser.Contains(role1.Name))
            {
                var result = userManager.AddToRole(user.Id, role1.Name);
            }
        }
    }
}
