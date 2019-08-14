using AutoMapper;
using DEV.Application.Car.Command;

namespace DEV.Application.Car.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarCommand, Domain.Entities.Car>();
        }
    }
}
