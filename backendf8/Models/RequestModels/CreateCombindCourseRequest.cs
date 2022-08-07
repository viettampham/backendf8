using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backendf8.Models.RequestModels
{
    public class CreateCombindCourseRequest
    {
        public List<Guid> Courses { get; set; }
        [Required]
        public string title { get; set; } 
    }
}