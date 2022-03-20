using MediatR;

namespace PhoneApp.Core.Application.Abstractions
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}
