using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backendf8.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Course> Courses { get; set; }
    }
}