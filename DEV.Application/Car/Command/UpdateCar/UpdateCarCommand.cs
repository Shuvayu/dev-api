using DEV.Application.Car.Model;
using MediatR;

namespace DEV.Application.Car.Command.UpdateCar
{
    public class UpdateCarCommand : IRequest<CarDto>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CountryManufactured { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }
}
