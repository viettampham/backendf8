using System;
using System.Collections.Generic;
using System.Linq;
using backendf8.Models;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;

namespace backendf8.Services.Impl
{
    public class LessonService:ILessonService
    {
        public readonly MasterDbContext _context;

        public LessonService(MasterDbContext context)
        {
            _context = context;
        }
        public List<LessonResponse> GetLession()
        {
            var listLesson = _context.Lessons.Select(lession => new LessonResponse
            {
                ID = lession.ID,
                Course_Id = lession.Course_Id,
                Course_progress = lession.Course_progress,
                End_of_course = lession.End_of_course,
                End_of_free = lession.End_of_free,
                has_end_time_logging = lession.has_end_time_logging,
                is_completed = lession.is_completed,
                is_logged = lession.is_logged,
                last_step_id = lession.last_step_id,
                learning_log = lession.learning_log,
                next_id = lession.next_id,
                pass_percent = lession.pass_percent,
                track_step = lession.track_step,
                user_solutions = lession.user_solutions,
            }).ToList();
            return listLesson;
        }

        public LessonResponse CreateLession(CreateLessonRequest request)
        {
            var newLession = new Lesson
            {
                ID = Guid.NewGuid(),
                Course_Id = request.Course_Id,
                Course_progress = request.Course_progress,
                End_of_course = request.End_of_course,
                End_of_free = request.End_of_free,
                has_end_time_logging = request.has_end_time_logging,
                is_completed = request.is_completed,
                is_logged = request.is_logged,
                last_step_id = request.last_step_id,
                learning_log = request.learning_log,
                next_id = request.next_id,
                pass_percent = request.pass_percent,
                track_step = request.track_step,
                user_solutions = request.user_solutions,
            };
            _context.Add(newLession);
            _context.SaveChanges();
            return new LessonResponse
            {
                ID = newLession.ID,
                Course_Id = newLession.Course_Id,
                Course_progress = newLession.Course_progress,
                End_of_course = newLession.End_of_course,
                End_of_free = newLession.End_of_free,
                has_end_time_logging = newLession.has_end_time_logging,
                is_completed = newLession.is_completed,
                is_logged = newLession.is_logged,
                last_step_id = newLession.last_step_id,
                learning_log = newLession.learning_log,
                next_id = newLession.next_id,
                pass_percent = newLession.pass_percent,
                track_step = newLession.track_step,
                user_solutions = newLession.user_solutions,
            };
        }

        public LessonResponse EditLession(EditLessonRequest request)
        {
            var editLession = _context.Lessons.FirstOrDefault(lession => lession.ID == request.ID);
            if (editLession ==null)
            {
                throw new Exception("This lession is not exsits");
            }
            editLession.ID  = request.ID;
            editLession.Course_Id = request.Course_Id;
            editLession.Course_progress = request.Course_progress;
            editLession.End_of_course = request.End_of_course;
            editLession.End_of_free = request.End_of_free;
            editLession.has_end_time_logging = request.has_end_time_logging;
            editLession.is_completed = request.is_completed;
            editLession.is_logged = request.is_logged;
            editLession.last_step_id = request.last_step_id;
            editLession.learning_log = request.learning_log;
            editLession.next_id = request.next_id;
            editLession.pass_percent = request.pass_percent;
            editLession.track_step = request.track_step;
            editLession.user_solutions = request.user_solutions;
            _context.SaveChanges();
            return new LessonResponse
            {
                ID  = editLession.ID,
                Course_Id = editLession.Course_Id,
                Course_progress = editLession.Course_progress,
                End_of_course = editLession.End_of_course,
                End_of_free = editLession.End_of_free,
                has_end_time_logging = editLession.has_end_time_logging,
                is_completed = editLession.is_completed,
                is_logged = editLession.is_logged,
                last_step_id = editLession.last_step_id,
                learning_log = editLession.learning_log,
                next_id = editLession.next_id,
                pass_percent = editLession.pass_percent,
                track_step = editLession.track_step,
                user_solutions = editLession.user_solutions,
            };
        }

        public LessonResponse DeleteLession(DeleteLessonRequest request)
        {
            var DelLession = _context.Lessons.Where(lession => lession.ID == request.ID).FirstOrDefault();
            if (DelLession == null)
            {
                throw new Exception("this lession is not found");
            }

            _context.Lessons.Remove(DelLession);
            _context.SaveChanges();
            return new LessonResponse
            {
                ID = DelLession.ID,
                Course_Id = DelLession.Course_Id,
                Course_progress = DelLession.Course_progress,
                End_of_course = DelLession.End_of_course,
                End_of_free = DelLession.End_of_free,
                has_end_time_logging = DelLession.has_end_time_logging,
                is_completed = DelLession.is_completed,
                is_logged = DelLession.is_logged,
                last_step_id = DelLession.last_step_id,
                learning_log = DelLession.learning_log,
                next_id = DelLession.next_id,
                pass_percent = DelLession.pass_percent,
                track_step = DelLession.track_step,
                user_solutions = DelLession.user_solutions,
            };
        }
    }
}