using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class TransactionBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "transaction.json");

        protected List<Transaction> LoadTransaction() // Method to load list of debts from JSON file
        {
            if (!File.Exists(FilePath)) return new List<Transaction>(); // Checking if the file exists


            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>(); // Deserializes the JSON string into a list
        }

        protected void SaveTransaction(List<Transaction> transactions) // Method to load list of debts from JSON file
        {
            var json = JsonSerializer.Serialize(transactions); // Serializes the list into JSON string

            File.WriteAllText(FilePath, json); // Write the JSON string to file
        }
    }
}
