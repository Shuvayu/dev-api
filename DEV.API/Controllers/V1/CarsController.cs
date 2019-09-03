using DEV.Application.Car.Command.CreateCar;
using DEV.Application.Car.Command.DiscountCars;
using DEV.Application.Car.Command.UpdateCar;
using DEV.Application.Car.Model;
using DEV.Application.Car.Query.GetCars;
using DEV.Application.Common.Command;
using DEV.Application.Common.Query;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DEV.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetCarsQuery();
            return Ok(await Mediator.Send(query));
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetQuery<CarDto> { Id = id };
            return Ok(await Mediator.Send(query));
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] CreateCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT: api/Cars
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] UpdateCarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteCommand { Id = id };
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("discount")]
        public async Task<IActionResult> Discount()
        {
            using (StreamReader streamReader = new StreamReader(Request.Body))
            {
                using (JsonReader jsonReader = new JsonTextReader(streamReader))
                {
                    List<CarDto> carlist = new JsonSerializer().Deserialize<List<CarDto>>(jsonReader);
                    DiscountCarsCommand command = new DiscountCarsCommand { CarList = carlist };
                    return Ok(await Mediator.Send(command));
                }
            }
        }
    }
}
