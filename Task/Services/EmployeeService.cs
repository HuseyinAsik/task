using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Services
{
    public class EmployeeService: IEmployeeService
    {
        readonly TaskContext db;

        public EmployeeService(TaskContext taskContext)
        {
            db = taskContext;
        }

      public async Task<List<Models.Dto.Employee>> GetEmployeeByRegion(int regionId)
        {
            List<Models.Dto.Employee> employees = new List<Models.Dto.Employee>();
            try
            {
                var regionIds = db.Regions.Where(x => x.ParentId == regionId).Select(x => x.Id).ToList();
                regionIds.Add(regionId);
                employees = db.Employees.Where(x => regionIds.Contains(x.RegionId)).Select(y => new Models.Dto.Employee { Name = y.Name, SurName = y.SurName }).ToList();                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return employees;
        }

        public async Task<HttpStatusCode> Create(Models.Dto.Employee employee)
        {
            try
            {
                if (db.Regions.Any(x => x.Id == employee.RegionId) && !db.Employees.Any(x => x.Name.Replace(" ", string.Empty).ToLower() == employee.Name.Replace(" ", string.Empty) && x.SurName.Replace(" ", string.Empty).ToLower() == employee.SurName.Replace(" ", string.Empty).ToLower() && x.RegionId == employee.RegionId))
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Name = employee.Name;
                    newEmployee.SurName = employee.SurName;
                    newEmployee.RegionId = employee.RegionId;

                    db.Employees.Add(newEmployee);
                    db.SaveChanges();

                    return HttpStatusCode.Created;
                }
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
