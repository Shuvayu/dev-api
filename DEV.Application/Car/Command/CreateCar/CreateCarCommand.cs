using MediatR;

namespace DEV.Application.Car.Command.CreateCar
{
    public class CreateCarCommand : IRequest<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CountryManufactured { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }
}
