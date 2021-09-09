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
        public async Task<CourseResponse> CourseInfoAsync(int id)
        {
            var CourseInfo = new CourseResponse();
            var CourseInfo2 = new CourseResponse() {id = 10, title="Ze"};

            using (var context = new ProGamerEntities())
            {
                CourseInfo = await context.ListCourse
                    .Where(u => u.Id == id)
                    .Select(u => new CourseResponse
                    {
                        id = u.Id,
                        title = u.Title,
                        description = u.Description,
                        duration = u.Duration,
                        value = u.Value,
                    })
                    .FirstOrDefaultAsync();
            }
            if (CourseInfo == null)
            {
                CourseInfo2.errorMessage = "Curso não encontrado, usando o curso 2";
                return CourseInfo2;
            }
            else
            {
                return CourseInfo;
            }
            
        }
        #endregion
        #endregion

    }
}