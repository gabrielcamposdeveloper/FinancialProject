using FinOpsCore.Domain.Common;
using FinOpsCore.Domain.Interfaces;
using MediatR;

namespace FinOpsCore.Application.Transactions.Commands.Liquidar;

public class LiquidarTransactionCommandHandler : IRequestHandler<LiquidarTransactionCommand, Result>
{
    private readonly ITransactionRepository _repository;

    public LiquidarTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(LiquidarTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _repository.GetByIdAsync(request.TransactionId);
        
        if (transaction is null)
            return Result.Failure("Transação não encontrada.");

        var result = transaction.Liquidar(request.LiquidationDate);
        
        if (result.IsFailure)
            return result;

        _repository.Update(transaction);
        var success = await _repository.UnitOfWork.CommitAsync(cancellationToken);

        if (!success)
            return Result.Failure("Houve um erro ao salvar a liquidação no banco de dados.");

        return Result.Success();
    }
}