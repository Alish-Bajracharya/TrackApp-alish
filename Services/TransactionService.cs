using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string transactionsFilePath;
        private List<TransactionModel> transactions;

        public TransactionService()
        {
            // Path to the JSON file
            transactionsFilePath = Path.Combine(AppContext.BaseDirectory, "Transaction.json");

            // Load transactions from the file initially
            transactions = LoadTransactionsFromFile();
        }

        // Load data from JSON file
        private List<TransactionModel> LoadTransactionsFromFile()
        {
            try
            {
                if (File.Exists(transactionsFilePath))
                {
                    string json = File.ReadAllText(transactionsFilePath);
                    return JsonSerializer.Deserialize<List<TransactionModel>>(json) ?? new List<TransactionModel>();
                }
                else
                {
                    return new List<TransactionModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading transactions from file: {ex.Message}");
                return new List<TransactionModel>(); // Ensure a return value in case of an exception
            }
        }

        // Save data back to JSON file
        private void SaveTransactionsToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(transactionsFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transactions to file: {ex.Message}");
            }
        }

        public Task<List<TransactionModel>> GetAllTransactionsAsync()
        {
            return Task.FromResult(transactions);
        }
       

        public Task AddTransactionAsync(TransactionModel transaction)
        {
            transaction.Id = transactions.Any() ? transactions.Max(t => t.Id) + 1 : 1;
            transactions.Add(transaction);
            SaveTransactionsToFile();
            return Task.CompletedTask;
        }

        public Task UpdateTransactionAsync(TransactionModel transaction)
        {
            var existingTransaction = transactions.FirstOrDefault(t => t.Id == transaction.Id);
            if (existingTransaction != null)
            {
                existingTransaction.Type = transaction.Type;
                existingTransaction.Date = transaction.Date;
                existingTransaction.Amount = transaction.Amount;
                existingTransaction.Tag = transaction.Tag;
                existingTransaction.Description = transaction.Description;
                SaveTransactionsToFile();
            }
            return Task.CompletedTask;
        }

        public Task DeleteTransactionAsync(int transactionId)
        {
            var transactionToRemove = transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transactionToRemove != null)
            {
                transactions.Remove(transactionToRemove);
                SaveTransactionsToFile();
            }
            return Task.CompletedTask;
        }
    }
}
