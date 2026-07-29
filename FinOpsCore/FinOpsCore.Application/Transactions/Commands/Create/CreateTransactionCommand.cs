using FinOpsCore.Domain.Common;
using MediatR;

namespace FinOpsCore.Application.Transactions.Commands.Create;

public class CreateTransactionCommand : IRequest<Result<Guid>>
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
}