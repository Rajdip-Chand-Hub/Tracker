using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class TransactionBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "transaction.jason");

        protected List<Transaction> LoadTransaction()
        {
            if (!File.Exists(FilePath)) return new List<Transaction>();

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        protected void SaveUsers(List<Transaction> transactions)
        {
            var json = JsonSerializer.Serialize(transactions);

            File.WriteAllText(FilePath, json);
        }
    }
}
