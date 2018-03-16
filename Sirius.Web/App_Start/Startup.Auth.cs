using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Managers;
using System.Data.Entity;

namespace Sirius.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(SiriusContext.Create);
            app.CreatePerOwinContext<SiriusUserManager>(SiriusUserManager.Create);
            app.CreatePerOwinContext<SiriusSignInManager>(SiriusSignInManager.Create);
            app.CreatePerOwinContext<SiriusRoleManager>(SiriusRoleManager.Create);

            Database.SetInitializer<SiriusContext>(new MigrateDatabaseToLatestVersion<SiriusContext, Sirius.Data.Migrations.Configuration>());
            SiriusContext context = new SiriusContext();
            context.Database.Initialize(false);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/user/login"),
                ExpireTimeSpan = TimeSpan.FromHours(3)
            });
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}