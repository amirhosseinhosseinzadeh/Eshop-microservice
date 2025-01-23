using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommand : IRequest<Unit>
{ }

public interface ICommand<out TRepsone> : IRequest<TRepsone>
{ }
