using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Task
{
    public interface IEmployeeService
    {
        Task<List<Models.Dto.Employee>> GetEmployeeByRegion(int regionId);
        Task<HttpStatusCode> Create(Models.Dto.Employee employee);
    }
}
