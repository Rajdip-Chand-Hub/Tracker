using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class DebtBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "debt.json"); // Creating a jason file

        protected List<Debt> LoadDebt() // Method to load list of debts from JSON file
        {
            if (!File.Exists(FilePath)) return new List<Debt>(); // Checking if the file exists

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>(); // Deserializes the JSON string into a list
        }

        protected void SaveDebt(List<Debt> debts) // Method to load list of debts from JSON file
        {
            var json = JsonSerializer.Serialize(debts); // Serializes the list into JSON string

            File.WriteAllText(FilePath, json); // Write the JSON string to file
        }
    }
}

