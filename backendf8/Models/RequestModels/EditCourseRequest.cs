using System;
using System.Collections.Generic;

namespace backendf8.Models.RequestModels
{
    public class EditCourseRequest
    {
        public Guid ID { get; set; }
        
        public string image_url { get; set; }
        
        public string title { get; set; }
        
        public List<Guid> CombinedCourses { get; set; }

    }
}