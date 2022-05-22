using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Interfaces;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        readonly IRegionService? _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        // POST api/<EmployeeController>
        [HttpPost("region")]
        public async Task<HttpStatusCode> Post([FromBody] Models.Dto.Region region)
        {
            if (string.IsNullOrEmpty(region.Name))
            {
                return HttpStatusCode.BadRequest;
            }

            return await _regionService.Create(region);

        }
    }
}
