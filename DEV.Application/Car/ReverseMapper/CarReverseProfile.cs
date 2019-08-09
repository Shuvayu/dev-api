using AutoMapper;
using DEV.Application.Car.Model;

namespace DEV.Application.Car.ReverseMapper
{
    public class CarReverseProfile : Profile
    {
        public CarReverseProfile()
        {
            CreateMap<Domain.Entities.Car, CarDto>();
        }
    }
}
