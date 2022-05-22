using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task.Interfaces;
using Task.Models;

namespace Task.Services
{
    public class RegionService:IRegionService
    {
        readonly TaskContext db;

        public RegionService(TaskContext taskContext)
        {
            db = taskContext;
        }

        public async Task<HttpStatusCode> Create(Models.Dto.Region region)
        {
            try
            {
                if ((region.ParentId == 0 || db.Regions.Any(x => x.Id == region.ParentId)) && !db.Regions.Any(x => x.Name.Replace(" ", string.Empty).ToLower() == region.Name.Replace(" ", string.Empty).ToLower() && x.ParentId == region.ParentId))
                {
                    Region newRegion = new Region();
                    newRegion.Name = region.Name;
                    newRegion.ParentId = region.ParentId;

                    db.Regions.Add(newRegion);
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
