using System;
using System.Collections.Generic;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;

namespace backendf8.Services
{
    public interface ICourseService
    {
        List<CourseResponse> GetListCourse();
        CourseResponse CreateCourse(CreateCourseRequest request);
        CourseResponse EditCourse(EditCourseRequest request);
        CourseResponse DeleteCourse(Guid id);

    }
}