using FinOpsCore.Domain.Common;
using MediatR;

namespace FinOpsCore.Application.Transactions.Commands.Liquidar;

public class LiquidarTransactionCommand : IRequest<Result>
{
    public Guid TransactionId { get; set; }
    public DateTime LiquidationDate { get; set; }
}