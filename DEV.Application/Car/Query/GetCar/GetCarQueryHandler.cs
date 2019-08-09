using AutoMapper;
using DEV.Application.Car.Model;
using DEV.Application.Common.Query;
using DEV.Application.Exceptions;
using DEV.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Query.GetCar
{
    public class GetCarQueryHandler : IRequestHandler<GetQuery<CarDto>, CarDto>
    {
        /// <summary>
        /// The Car Repository
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public GetCarQueryHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<CarDto> Handle(GetQuery<CarDto> request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetACarAsync(request.Id);
            if (car == null)
            {
                throw new NotFoundException(nameof(car), request.Id);
            }
            return _mapper.Map<CarDto>(car);
        }
    }
}
