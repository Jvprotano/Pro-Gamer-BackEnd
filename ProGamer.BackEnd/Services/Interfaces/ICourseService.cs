using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Models.Response;
using System.Threading.Tasks;

namespace ProGamer.BackEnd.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse> GetAsync(int id);

        Task RegisterCourseAsync(RegisterCourseRequest request);
    }
}