using System.Collections.Generic;
using System.Threading.Tasks;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionModel>> GetAllTransactionsAsync();
        Task AddTransactionAsync(TransactionModel transaction);
        Task UpdateTransactionAsync(TransactionModel transaction);
        Task DeleteTransactionAsync(int transactionId);
    }
}
