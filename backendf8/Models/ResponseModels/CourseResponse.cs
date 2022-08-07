using System;
using System.Collections.Generic;

namespace backendf8.Models.ResponseModels
{
    public class CourseResponse
    {
        public string description { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public Guid ID { get; set; }
        public string image { get; set; }
        public string image_url { get; set; }
        public bool is_coming_soon { get; set; }
        public bool is_pre_order { get; set; }
        public bool is_pro { get; set; }
        public bool is_published { get; set; }
        public bool is_registered { get; set; }
        public bool is_selling { get; set; }
        public string last_completed_at { get; set; }
        public int price { get; set; }
        public string related_course { get; set; }
        public string slug { get; set; }
        public int student_course { get; set; }
        public string title { get; set; }
        public int user_progress { get; set; }
        public string video { get; set; }
        public string video_type { get; set; }
        public string video_url { get; set; }
        public List<CombinedCourse> CombinedCourses { get; set; }

    }
}