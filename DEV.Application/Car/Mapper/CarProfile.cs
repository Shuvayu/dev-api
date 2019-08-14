using AutoMapper;
using DEV.Application.Car.Command.CreateCar;
using DEV.Application.Car.Command.UpdateCar;

namespace DEV.Application.Car.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarCommand, Domain.Entities.Car>();
            CreateMap<UpdateCarCommand, Domain.Entities.Car>();
        }
    }
}
