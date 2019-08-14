using AutoMapper;
using DEV.Persistence.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DEV.Application.Car.Command
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        /// <summary>
        /// The Car Repository
        /// </summary>
        private readonly ICarRepository _carRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var carToAdd = _mapper.Map<Domain.Entities.Car>(request);
            return await _carRepository.AddACarAsync(carToAdd);
        }
    }
}
