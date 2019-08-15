using AutoMapper;
using DEV.Application.Common.Command;
using DEV.Application.Exceptions;
using DEV.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Command.DeleteCar
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        /// <summary>
        /// The Car Repository
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetACarAsync(request.Id);
            if (car == null)
            {
                throw new NotFoundException(nameof(car), request.Id);
            }

            await _carRepository.DeleteACarAsync(request.Id);
            return Unit.Value;
        }
    }
}
