using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirius.Web.Models
{
    public class JsonResponse
    {
        public bool Successful { get; set; }
        public string Html { get; set; }
        public string ErrorMessage { get; set; }
        public string Url { get; set; }

        private JsonResponse()
        { }

        public static JsonResponse Success()
        {
            return Success(null);
        }

        public static JsonResponse Success(string html)
        {
            return new JsonResponse
            {
                Successful = true,
                Html = html
            };
        }

        public static JsonResponse Error(string errorMessage)
        {
            return new JsonResponse
            {
                Successful = false,
                Html = errorMessage
            };
        }

        public static JsonResponse RedirectTo(string html, string url)
        {
            return new JsonResponse
            {
                Successful = true,
                Html = html,
                Url = url
            };
        }
    }
}