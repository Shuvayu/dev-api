using AutoMapper;
using DEV.Application.Car.Model;
using DEV.Application.Exceptions;
using DEV.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Command.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDto>
    {
        /// <summary>
        /// The Car Repository
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<CarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _carRepository.GetACarAsync(request.Id);
            if (car == null)
            {
                throw new NotFoundException(nameof(car), request.Id);
            }
            var domainModel = _mapper.Map<Domain.Entities.Car>(request);
            await _carRepository.UpdateACarAsync(domainModel);
            var updatedCar = _carRepository.GetACarAsync(request.Id);
            var dtoModel = _mapper.Map<CarDto>(updatedCar);
            return dtoModel;
        }
    }
}
