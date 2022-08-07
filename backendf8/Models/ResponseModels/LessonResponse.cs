using System;

namespace backendf8.Models.ResponseModels
{
    public class LessonResponse
    {
        public Guid ID { get; set; }
        public Guid Continue_ID { get; set; }
        
        public Guid Course_Id { get; set; }
        public Course Courses { get; set; }
        
        public int Course_progress { get; set; }
        public bool End_of_course { get; set; }
        public bool End_of_free { get; set; }
        public bool has_end_time_logging { get; set; }
        public bool is_completed { get; set; }
        public bool is_logged { get; set; }
        public Guid last_step_id { get; set; }
        public string learning_log { get; set; }
        public Guid next_id { get; set; }
        public int pass_percent { get; set; }
        public string track_step { get; set; }
        public string user_solutions { get; set; }

    }
}