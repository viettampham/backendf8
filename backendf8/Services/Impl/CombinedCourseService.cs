using System;
using System.Collections.Generic;
using System.Linq;
using backendf8.Models;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace backendf8.Services.Impl
{
    public class CombinedCourseService:ICombinedCourseService
    {
        public readonly MasterDbContext _context;

        public CombinedCourseService(MasterDbContext context)
        {
            _context = context;
        }
        public List<CombinedCourseResponse> Getlist()
        {
            var listcombinedcourse = _context.CombinedCourses.Select(combinedCourse => new CombinedCourseResponse
            {
                ID = combinedCourse.ID,
                image = combinedCourse.image,
                image_url = combinedCourse.image_url,
                slug = combinedCourse.slug,
                title = combinedCourse.title,
                Courses = combinedCourse.Courses
            }).ToList();
            return listcombinedcourse;
        }

        public CombinedCourseResponse CreateCombinedCourse(CreateCombindCourseRequest request)
        {
            var courses = new List<Course>();

            request.Courses
                .ForEach(course =>
                {
                    var newCourse = _context.Courses.FirstOrDefault(c => c.ID == course);
                    if (newCourse == null)
                    {
                        throw new Exception("Course not exist!!");
                    }
                    courses.Add(newCourse);
                });
            
            var newCombinedCourse = new CombinedCourse
            {
                ID = Guid.NewGuid(),
                title = request.title,
                Courses = courses
            };
            _context.CombinedCourses.Add(newCombinedCourse);
            _context.SaveChanges();
            return new CombinedCourseResponse
            {
                ID = newCombinedCourse.ID,
                image = newCombinedCourse.image,
                image_url = newCombinedCourse.image_url,
                slug = newCombinedCourse.slug,
                title = newCombinedCourse.title,
                Courses = courses
            };
        }

        public CombinedCourseResponse EditCombinedcourse(EditCombinedCourseRequest request)
        {
            var editcombined =
                _context.CombinedCourses
                    .Include(c => c.Courses)
                    .FirstOrDefault(combinedCourse => combinedCourse.ID == request.id);
            if (editcombined==null)
            {
                throw new Exception("this combined course is not exsits");
            }
            
            editcombined.title = request.title;
            editcombined.Courses.Clear();foreach (var id in request.Courses)
            {
                var targetCourse = _context.Courses.FirstOrDefault(c => c.ID == id);
                if (targetCourse == null)
                {
                    throw new Exception("Course not Exsits");
                }
                if ( editcombined.Courses != null)
                {
                    editcombined.Courses.Add(targetCourse);
                }
                else
                { 
                    editcombined.Courses = new List<Course> { targetCourse };
                }
            }
            
            
            _context.SaveChanges();
            return new CombinedCourseResponse
            {
                ID = editcombined.ID,
                image = editcombined.image,
                image_url = editcombined.image_url,
                slug = editcombined.slug,
                title = editcombined.title,
                Courses = editcombined.Courses
            };
        }

        public CombinedCourseResponse DeleteCombinedCourse(Guid id)
        {
            var delCombined = _context.CombinedCourses
                .FirstOrDefault(combinedcourse => combinedcourse.ID == id);
            if (delCombined==null)
            {
                throw new Exception("This combinedcourse is not found");
            }

            _context.Remove(delCombined);
            _context.SaveChanges();
            return new CombinedCourseResponse
            {
                ID = delCombined.ID,
                image = delCombined.image,
                image_url = delCombined.image_url,
                slug = delCombined.slug,
                title = delCombined.title
            };
        }
    }
}