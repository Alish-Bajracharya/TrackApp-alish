using System.Text.Json;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public class DebtService : IDebtService
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Debts.json");
        private List<Debt> _debts = new();

        public DebtService()
        {
            LoadDebts();
        }

        // Load debts from JSON file
        private void LoadDebts()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var json = File.ReadAllText(_filePath);
                    _debts = JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading debts: {ex.Message}");
            }
        }

        // Save debts to JSON file
        private void SaveDebts()
        {
            try
            {
                var json = JsonSerializer.Serialize(_debts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving debts: {ex.Message}");
            }
        }

        // Fetch all debts
        public async Task<List<Debt>> GetAllDebtsAsync()
        {
            Console.WriteLine("Fetching debts...");
            var debts = await Task.Run(() => _debts); 
            foreach (var debt in debts)
            {
                Console.WriteLine($"Debt: {debt.Id}, {debt.Title}, {debt.Status}");
            }
            return debts;
        }

        // Add a new debt
        public async Task AddDebtAsync(Debt debt)
        {
            debt.Id = _debts.Any() ? _debts.Max(d => d.Id) + 1 : 1;
            _debts.Add(debt);
            SaveDebts();
            await Task.CompletedTask;
        }

        // Update an existing debt
        public async Task UpdateDebtAsync(Debt debt)
        {
            var existing = _debts.FirstOrDefault(d => d.Id == debt.Id);
            if (existing != null)
            {
                existing.Title = debt.Title ;
                existing.DueDate = debt.DueDate;
                existing.Amount = debt.Amount;
                existing.Status = debt.Status;
                existing.Tags = debt.Tags;
                SaveDebts();
            }
            await Task.CompletedTask;
        }

        // Delete a debt by ID
        public async Task DeleteDebtAsync(int id)
        {
            _debts.RemoveAll(d => d.Id == id);
            SaveDebts();
            await Task.CompletedTask;
        }
    }

   
}
