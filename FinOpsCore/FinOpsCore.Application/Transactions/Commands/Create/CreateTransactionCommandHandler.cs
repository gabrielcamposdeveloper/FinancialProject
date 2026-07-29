using FinOpsCore.Domain.Common;
using FinOpsCore.Domain.Entities;
using FinOpsCore.Domain.Interfaces;
using MediatR;

namespace FinOpsCore.Application.Transactions.Commands.Create;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result<Guid>>
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionResult = Transaction.Create(request.Description, request.Amount, request.DueDate);

        if (transactionResult.IsFailure)
        {
            return Result<Guid>.Failure(transactionResult.Error);
        }

        var transaction = transactionResult.Value!;

        await _repository.AddAsync(transaction);

        var success = await _repository.UnitOfWork.CommitAsync(cancellationToken);

        if (!success)
        {
            return Result<Guid>.Failure("Ocorreu um erro ao tentar salvar a transação no banco de dados.");
        }

        return Result<Guid>.Success(transaction.Id);
    }
}