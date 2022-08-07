using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backendf8.Models.RequestModels
{
    public class CreateCourseRequest
    {
        [Required]
        public string title { get; set; }
        public string image_url { get; set; }
        
        
        
        public List<Guid> CombinedCoursesId { get; set; }

    }
}