using System;
using System.Collections.Generic;

namespace backendf8.Models.RequestModels
{
    public class EditCombinedCourseRequest
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public List<Guid> Courses { get; set; } 
    }
}