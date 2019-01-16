using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace KendoDemo.API.Controllers
{
    [Produces("application/json")]
    public class KendoController : Controller
    {
        private readonly KendoContext context;

        public KendoController(KendoContext context) => this.context = context;

        // GET api/values
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            StringValues Id;
            Request.HttpContext.Request.Headers.TryGetValue("id", out Id);

            var kendos = context.Kendos.AsQueryable();

            var result = kendos.AsEnumerable()
                        .Select((obj, index) => new { obj.Id, Index = index }).ToList()
                        .FirstOrDefault(x => x.Id == Convert.ToInt32(Id[0]));

            int SelectedData = (result != null) ? result.Index + 1 : 0;

            Request.HttpContext.Response.Headers.Add("X-Total-Count", SelectedData.ToString());
            return Ok(kendos);
        }

        
    }
}
