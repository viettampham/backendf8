using System.Collections.Generic;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;

namespace backendf8.Services
{
    public interface ILessonService
    {
        List<LessonResponse> GetLession();
        LessonResponse CreateLession(CreateLessonRequest request);
        LessonResponse EditLession(EditLessonRequest request);
        LessonResponse DeleteLession(DeleteLessonRequest request);

    }
}