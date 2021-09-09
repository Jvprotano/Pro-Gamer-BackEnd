using ProGamer.BackEnd.Entities;
using ProGamer.BackEnd.Models.Response;
using ProGamer.BackEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProGamer.BackEnd.Services.Implements
{
    public class CourseService : ICourseService
    {
        #region Methods
        #region CursoInfoAsync
        public async Task<CourseResponse> GetAsync(int id)
        {
            var courseInfo = new CourseResponse();

            using (var context = new ProGamerEntities())
            {
                courseInfo = await context.ListCourse
                    .Include(u=> u.User)
                    .Include(u=> u.CourseCategory)
                    .Where(u => u.Id == id && u.Active)
                    .Select(u => new CourseResponse
                    {
                        Id = u.Id,
                        Title = u.Title,
                        Description = u.Description,
                        Duration = u.Duration,
                        Value = u.Value,
                        InstrutorId = u.UserId,
                        InstrutorName = u.User.Name,
                        InstrutorLastName = u.User.LastName,
                        CategoryName = u.CourseCategory.Name,
                        CreationDate = u.DateUtcInsert
                    })
                    .FirstOrDefaultAsync();
            }

            return courseInfo;
        }
        #endregion
        #endregion

    }
}