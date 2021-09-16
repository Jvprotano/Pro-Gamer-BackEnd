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

                homeData.ListCourseRecent = await context.ListCourse
                    .Include(c => c.User)
                    .Where(c => c.Active)
                    .OrderByDescending(c => c.DateUtcInsert)
                    .Select(c => new CourseCardResponse
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                        InstructorName = c.User.Name + " " + c.User.LastName,
                    })
                    .Take(12)
                    .AsNoTracking()
                    .ToListAsync();

                Random random = new Random();

                homeData.listCourseRecommended = await context.ListCourse
                  .Include(c => c.User)
                  .Where(c => c.Active)
                  .Select(c => new CourseCardResponse
                  {
                      Id = c.Id,
                      Title = c.Title,
                      Description = c.Description,
                      InstructorName = c.User.Name + " " + c.User.LastName,
                  })
                  .OrderBy(c => random.Next())
                  .Take(12)
                  .AsNoTracking()
                  .ToListAsync();
            }

            return homeData;
        }
        #endregion

        #endregion
    }
}