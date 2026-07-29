using FinOpsCore.Domain.Entities;
using FinOpsCore.Domain.Interfaces;
using FinOpsCore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinOpsCore.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task AddAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
    }

    public void Update(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
    }
}