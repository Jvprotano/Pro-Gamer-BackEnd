using ProGamer.BackEnd.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProGamer.BackEnd.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse> GetAsync(int id);
    }
}