using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
    new Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
    new Task Handle(TCommand command, CancellationToken cancellationToken);
}
