using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sirius.Web.Areas.thoth.Models
{
    public class OrganizationViewModel
    {
        [Required(ErrorMessage="Organization Name Required")]
        public string FullName { get; set; }
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Email domain Required")]
        public string DomainName { get; set; }

        public byte[] LogoImageContent { get; set; }
        public string FileMimeType { get; set; }
    }
}