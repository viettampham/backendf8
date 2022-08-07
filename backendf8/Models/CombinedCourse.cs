using System;
using System.Collections.Generic;

namespace backendf8.Models
{
    public class CombinedCourse
    {
        public Guid ID { get; set; }
        public string image { get; set; }
        public string image_url { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public List<Course> Courses { get; set; }
    }
}