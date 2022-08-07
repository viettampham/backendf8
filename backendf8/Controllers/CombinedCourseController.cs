using System;
using backendf8.Models.RequestModels;
using backendf8.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendf8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CombinedCourseController:ControllerBase
    {
        private readonly ICombinedCourseService _combinedCourseService;

        public CombinedCourseController(ICombinedCourseService combinedCourseService)
        {
            _combinedCourseService = combinedCourseService;
        }
        [HttpGet("get-list-combined-course")]
        public IActionResult GetList()
        {
            var listcombinedcourse = _combinedCourseService.Getlist();
            return Ok(listcombinedcourse);
        }

        [HttpPost("create-combinedcourse")]
        public IActionResult CreateCombinedCourse([FromBody] CreateCombindCourseRequest request)
        {
            var newcombinedcourse = _combinedCourseService.CreateCombinedCourse(request);
            return Ok(newcombinedcourse);
        }
        [HttpPost("edit-combined-course")]
        public IActionResult EditcombinedCourse([FromBody] EditCombinedCourseRequest request)
        {
            var editCombined = _combinedCourseService.EditCombinedcourse(request);
            return Ok(editCombined);
        }

        [HttpDelete("delete-combined-course/{id}")]
        public IActionResult DeleteCombinedCourse(Guid id)
        {
            var delCombined = _combinedCourseService.DeleteCombinedCourse(id);
            return Ok(delCombined);
        }
    }
}