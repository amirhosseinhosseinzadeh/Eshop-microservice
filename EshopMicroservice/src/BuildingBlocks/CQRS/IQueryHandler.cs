using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
    new Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}