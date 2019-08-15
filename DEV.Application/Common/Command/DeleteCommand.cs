using MediatR;

namespace DEV.Application.Common.Command
{
    public class DeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
