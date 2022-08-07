using System;
using System.Collections.Generic;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;

namespace backendf8.Services
{
    public interface ICombinedCourseService
    {
        List<CombinedCourseResponse> Getlist();
        CombinedCourseResponse CreateCombinedCourse(CreateCombindCourseRequest request);
        CombinedCourseResponse EditCombinedcourse(EditCombinedCourseRequest request);
        CombinedCourseResponse DeleteCombinedCourse(Guid id);

    }
}