using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Task.Interfaces
{
    public interface IRegionService
    {
        Task <HttpStatusCode> Create(Models.Dto.Region region);
    }
}
