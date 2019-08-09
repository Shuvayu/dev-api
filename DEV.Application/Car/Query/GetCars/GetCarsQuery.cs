using DEV.Application.Car.Model;
using MediatR;
using System.Collections.Generic;

namespace DEV.Application.Car.Query.GetCars
{
    public class GetCarsQuery : IRequest<List<CarDto>>
    {
    }
}
