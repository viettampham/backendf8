using backendf8.Models.RequestModels;
using backendf8.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendf8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController:ControllerBase
    {
        private readonly ILessonService _lessionService;

        public LessonController(ILessonService lessionService)
        {
            _lessionService = lessionService;
        }

        [HttpGet("get-list-lession")]
        public IActionResult GetlistLession()
        {
            var listlession = _lessionService.GetLession();
            return Ok(listlession);
        }

        [HttpPost("Create-lession")]
        public IActionResult CreateLession([FromBody] CreateLessonRequest request)
        {
            var newlession = _lessionService.CreateLession(request);
            return Ok(newlession);
        }

        [HttpPost("edit-lession")]
        public IActionResult EditLesison([FromBody] EditLessonRequest request)
        {
            var editlession = _lessionService.EditLession(request);
            return Ok(editlession);
        }

        [HttpDelete("delete-lession")]
        public IActionResult DeleteLession(DeleteLessonRequest request)
        {
            var targetlession = _lessionService.DeleteLession(request);
            return Ok(targetlession);
        }
    }
}