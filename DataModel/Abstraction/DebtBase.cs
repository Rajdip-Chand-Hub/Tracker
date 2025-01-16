using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class DebtBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "debt.json");

        protected List<Debt> LoadDebt()
        {
            if (!File.Exists(FilePath)) return new List<Debt>();

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>();
        }

        protected void SaveDebt(List<Debt> debts)
        {
            var json = JsonSerializer.Serialize(debts);

            File.WriteAllText(FilePath, json);
        }
    }
}

