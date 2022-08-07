using System;
using System.Collections.Generic;
using System.Linq;
using backendf8.Models;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace backendf8.Services.Impl
{
    public class CourseService:ICourseService
    {
        public readonly MasterDbContext _context;

        public CourseService(MasterDbContext context)
        {
            _context = context;
        }
        public List<CourseResponse> GetListCourse()
        {
            var listcourse = _context.Courses.Select(course => new CourseResponse
            {
                ID = course.ID,
                description = course.description,
                icon = course.icon,
                icon_url = course.icon_url,
                image = course.image,
                image_url = course.image_url,
                is_coming_soon = course.is_coming_soon,
                is_pre_order = course.is_pre_order,
                is_pro = course.is_pro,
                is_published = course.is_published,
                is_registered = course.is_registered,
                is_selling = course.is_selling,
                last_completed_at = course.last_completed_at,
                price = course.price,
                related_course = course.related_course,
                slug = course.slug,
                student_course = course.student_course,
                title = course.title,
                user_progress = course.user_progress,
                video = course.video,
                video_type = course.video_type,
                video_url = course.video_url,
                CombinedCourses = course.CombinedCourses
            }).ToList();
            return listcourse;
        }

        public CourseResponse CreateCourse(CreateCourseRequest request)
        {
            var checknameCourses = _context.Courses.Count(course => course.title.Equals(request.title)) == 0;
            {
                if (!checknameCourses)
                {
                    throw new Exception("this course is exsist");
                }
            }
            
            var combinedCourses = new List<CombinedCourse>();
            request.CombinedCoursesId.ForEach(combinedCourse =>
            {
                var newCombinedCourse = _context.CombinedCourses.FirstOrDefault(c => c.ID == combinedCourse);
                if (newCombinedCourse == null)
                {
                    throw new Exception("CombinedCourses not exist!");
                }

                combinedCourses.Add(newCombinedCourse);
            });
            
            var newCourse = new Course
            {
                ID = Guid.NewGuid(),
                
                image_url = request.image_url,
                
                title = request.title,
                
                CombinedCourses = combinedCourses
            };
            _context.Add(newCourse);
            _context.SaveChanges();
            return new CourseResponse
            {
                ID = newCourse.ID,
                description = newCourse.description,
                icon = newCourse.icon,
                icon_url = newCourse.icon_url,
                image = newCourse.image,
                image_url = newCourse.image_url,
                is_coming_soon = newCourse.is_coming_soon,
                is_pre_order = newCourse.is_pre_order,
                is_pro = newCourse.is_pro,
                is_published = newCourse.is_published,
                is_registered = newCourse.is_registered,
                is_selling = newCourse.is_selling,
                last_completed_at = newCourse.last_completed_at,
                price = newCourse.price,
                related_course = newCourse.related_course,
                slug = newCourse.slug,
                student_course = newCourse.student_course,
                title = newCourse.title,
                user_progress = newCourse.user_progress,
                video = newCourse.video,
                video_type = newCourse.video_type,
                video_url = newCourse.video_url,
                CombinedCourses = combinedCourses
            };
        }

        public CourseResponse EditCourse(EditCourseRequest request)
        {
            var editCourse = _context.Courses.Include(c => c.CombinedCourses)
                .FirstOrDefault(course => course.ID == request.ID);
            if (editCourse==null)
            {
                throw new Exception("Data not exsits");
            }
            
            editCourse.CombinedCourses.Clear();

            editCourse.title = request.title;
            editCourse.image_url = request.image_url;
            
            
            foreach (var combinedId in request.CombinedCourses)
            {
                var targetCombined = _context
                    .CombinedCourses
                    .Include(course => course.Courses)
                    .FirstOrDefault(c => c.ID == combinedId);
                if (targetCombined == null)
                {
                    throw new Exception("Combined not exsits");
                }

                if (targetCombined.Courses !=null)
                {
                    editCourse.CombinedCourses.Add(targetCombined);
                }
                else
                {
                    editCourse.CombinedCourses = new List<CombinedCourse> { targetCombined };
                }
            }
            
            /*request.CombinedCourses.ForEach(combinedCourseId =>
            {
                var combinedCourse = _context.CombinedCourses.FirstOrDefault(cb => cb.ID == combinedCourseId);
                if (combinedCourse == null)
                {
                    throw new Exception("Nhóm khóa học không tồn tại");
                }
                if ( editCourse.CombinedCourses!= null)
                {
                    editCourse.CombinedCourses.Add(combinedCourse);
                }
                else
                { 
                    editCourse.CombinedCourses = new List<CombinedCourse> { combinedCourse};
                }
            });*/


            _context.SaveChanges();
            return new CourseResponse
            {
                ID = editCourse.ID,
                description = editCourse.description,
                icon = editCourse.icon,
                icon_url = editCourse.icon_url,
                image = editCourse.image,
                image_url = editCourse.image_url,
                is_coming_soon = editCourse.is_coming_soon,
                is_pre_order = editCourse.is_pre_order,
                is_pro = editCourse.is_pro,
                is_published = editCourse.is_published,
                is_registered = editCourse.is_registered,
                is_selling = editCourse.is_selling,
                last_completed_at = editCourse.last_completed_at,
                price = editCourse.price,
                related_course = editCourse.related_course,
                slug = editCourse.slug,
                student_course = editCourse.student_course,
                title = editCourse.title,
                user_progress = editCourse.user_progress,
                video = editCourse.video,
                video_type = editCourse.video_type,
                video_url = editCourse.video_url,
                CombinedCourses = editCourse.CombinedCourses

            };
        }

        public CourseResponse DeleteCourse(Guid id)
        {
            var targetCourse = _context.Courses.Where(course => course.ID == id).FirstOrDefault();
            if (targetCourse ==null)
            {
                throw new Exception("this course not exsits");
            }

            _context.Remove(targetCourse);
            _context.SaveChanges();
            return new CourseResponse
            {
                /*description = targetCourse.description,*/
                icon = targetCourse.icon,
                icon_url = targetCourse.icon_url,
                image = targetCourse.image,
                image_url = targetCourse.image_url,
                is_coming_soon = targetCourse.is_coming_soon,
                is_pre_order = targetCourse.is_pre_order,
                is_pro = targetCourse.is_pro,
                is_published = targetCourse.is_published,
                is_registered = targetCourse.is_registered,
                is_selling = targetCourse.is_selling,
                last_completed_at = targetCourse.last_completed_at,
                price = targetCourse.price,
                related_course = targetCourse.related_course,
                slug = targetCourse.slug,
                student_course = targetCourse.student_course,
                title = targetCourse.title,
                user_progress = targetCourse.user_progress,
                video = targetCourse.video,
                video_type = targetCourse.video_type,
                video_url = targetCourse.video_url,
            };
        }
    }
}