using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService? _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet("region/{id}/employees")]
        public async Task<List<Models.Dto.Employee>> GetEmployeesAsync(int id)
        {
            return await _employeeService.GetEmployeeByRegion(id);
        }

        // POST api/<EmployeeController>
        [HttpPost("employee")]
        public async Task<HttpStatusCode> Post([FromBody] Models.Dto.Employee employee)
        {
            if(string.IsNullOrEmpty(employee.Name) || string.IsNullOrEmpty(employee.SurName) || employee.RegionId == 0)
            {
                return HttpStatusCode.BadRequest;
            }
           
            return await _employeeService.Create(employee);

        }

    }
}
