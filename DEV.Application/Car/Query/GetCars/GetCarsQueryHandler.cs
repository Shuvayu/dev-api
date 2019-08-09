﻿using AutoMapper;
using DEV.Application.Car.Model;
using DEV.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Query.GetCars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<CarDto>>
    {
        /// <summary>
        /// The Car Repository
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public GetCarsQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public Task<List<CarDto>> Handle(GetCarsQuery getCarsQuery, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
