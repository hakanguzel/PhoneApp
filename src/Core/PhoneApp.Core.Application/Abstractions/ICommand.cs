using MediatR;

namespace PhoneApp.Core.Application.Abstractions
{
    public interface ICommand<TResult> : IRequest<TResult> { }
}
