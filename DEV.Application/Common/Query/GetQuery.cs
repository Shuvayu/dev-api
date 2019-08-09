using MediatR;

namespace DEV.Application.Common.Query
{
    public class GetQuery<T> : IRequest<T>
    {
        /// <summary>
        /// get sets the ID an API
        /// </summary>
        public int Id { get; set; }
    }
}
