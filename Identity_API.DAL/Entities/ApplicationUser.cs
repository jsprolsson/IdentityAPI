using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_API.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? AccessToken { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
}
