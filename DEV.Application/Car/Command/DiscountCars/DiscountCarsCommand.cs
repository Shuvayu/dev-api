using DEV.Application.Car.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEV.Application.Car.Command.DiscountCars
{
    public class DiscountCarsCommand : IRequest<List<CarDto>>
    {
        public List<CarDto> CarList { get; set; }
    }
}
