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
    public class HomeAppService : IHomeAppService
    {
        #region Methods

        #region LoadDataHome
        public async Task<HomeResponse> LoadDataHomeAsync()
        {
            var homeData = new HomeResponse();

            using (var context = new ProGamerEntities())
            {
                homeData.ListGame = await context.ListGame
                    .Where(g => g.Active)
                    .Select(g => new GameCardResponse
                    {
                        Id = g.Id,
                        Name = g.Name,
                        ImageUrl = g.ImageUrl,
                    })
                    .AsNoTracking()
                    .ToListAsync();

                var listCourse = await context.ListCourse
                    .Include(c => c.User)
                    .Where(c => c.Active)
                     .Select(c => new CourseCardResponse
                     {
                         Id = c.Id,
                         Title = c.Title,
                         Description = c.Description,
                         InstructorName = c.User.Name + " " + c.User.LastName,
                         DateUtcInsert = c.DateUtcInsert,
                     })
                     .AsNoTracking()
                    .ToListAsync();

                homeData.ListCourseRecent = listCourse.OrderByDescending(c => c.DateUtcInsert).Take(12).ToList();

                Random random = new Random();
                homeData.listCourseRecommended = listCourse.OrderBy(c => random.Next()).Take(12).ToList();
            }

            return homeData;
        }
        #endregion

        #endregion
    }
}