using ProGamer.BackEnd.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGamer.BackEnd.Services.Interfaces
{
    public interface IHomeAppService
    {
        Task<HomeResponse> LoadDataHomeAsync();
    }
}
