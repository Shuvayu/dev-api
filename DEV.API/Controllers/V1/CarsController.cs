using DEV.Application.Car.Query.GetCars;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEV.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var query = new GetCarsQuery();
            return Ok(await Mediator.Send(query));
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
