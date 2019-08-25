using AutoMapper;
using DEV.Application.Car.Model;
using DEV.Domain.Rules.DiscountRules;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Command.DiscountCars
{
    public class DiscountCarsCommandHandler : IRequestHandler<DiscountCarsCommand, List<CarDto>>
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public DiscountCarsCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<List<CarDto>> Handle(DiscountCarsCommand request, CancellationToken cancellationToken)
        {
            // Setup chain of discount rule execution
            var totalCostDiscount = new TotalCostDiscount();
            var totalCountDiscount = new TotalCountDiscount();
            var yearBasedDiscount = new YearBasedDiscount();

            totalCostDiscount.SetSuccessor(totalCountDiscount);
            totalCountDiscount.SetSuccessor(yearBasedDiscount);

            var cars = _mapper.Map<List<Domain.Entities.Car>>(request.CarList);

            totalCostDiscount.HandleRequest(cars);

            return Task.FromResult(_mapper.Map<List<CarDto>>(cars));
        }
    }
}
