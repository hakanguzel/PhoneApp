using MediatR;

namespace PhoneApp.Core.Application.Abstractions
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult> { }
}
