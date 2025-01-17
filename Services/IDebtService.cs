using System.Collections.Generic;
using System.Threading.Tasks;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public interface IDebtService
    {
        Task<List<Debt>> GetAllDebtsAsync();
        Task AddDebtAsync(Debt debt);
        Task UpdateDebtAsync(Debt debt);
        Task DeleteDebtAsync(int id);
    }
}
