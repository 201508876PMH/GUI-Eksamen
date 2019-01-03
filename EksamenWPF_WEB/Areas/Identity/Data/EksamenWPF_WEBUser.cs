using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EksamenWPF_WEB.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EksamenWPF_WEBUser class
    public class EksamenWPF_WEBUser : IdentityUser
    {
        [PersonalData]
        public string TelephoneNumber { get; set; }
    }
}
