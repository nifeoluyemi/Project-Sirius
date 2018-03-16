using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace Sirius.Web.Helpers.CookiesHelpers
{
    public class Cookie
    {
        public HttpCookie CreateCookie()
        {
            HttpCookie myCookie = new HttpCookie("MyTestCookie");
            DateTime now = DateTime.Now;

            myCookie.Value = now.ToString();
            myCookie.Expires = now.AddYears(50);

            return myCookie;
        }

        public HttpCookie CreateUserCookie(string email, string orgName, byte[] userImage, string userImageType)
        {
            HttpCookie myCookie = new HttpCookie("UserInformation");

            string UserImageString = ASCIIEncoding.ASCII.GetString(userImage);
            
            myCookie.Values.Add("UserEmail", email);
            myCookie.Values.Add("OrganizationName", orgName);
            myCookie.Values.Add("UserImage", UserImageString);
            myCookie.Values.Add("UserImageType", userImageType);
            myCookie.Expires = DateTime.UtcNow.AddMonths(5);



            return myCookie;
        }

        public void DeleteCookie()
        {
            
        }
    }
}