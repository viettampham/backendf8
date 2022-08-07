using System;
using backendf8.Models.RequestModels;
using backendf8.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendf8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("Get-all-list")]
        public IActionResult Getlistcourse()
        {
            var listcourse = _courseService.GetListCourse();
            return Ok(listcourse);
        }

        [HttpPost("Create-course")]
        public IActionResult CreateCourse([FromBody]CreateCourseRequest request)
        {
            var newcourse = _courseService.CreateCourse(request);
            return Ok(newcourse);
        }

        [HttpPost("edit-course")]
        public IActionResult EditCourse([FromBody] EditCourseRequest request)
        {
            var targetcourse = _courseService.EditCourse(request);
            return Ok(targetcourse);
        }

        [HttpDelete("delete-course/{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            var delcourse = _courseService.DeleteCourse(id);
            return Ok(delcourse);
        }
    }
}