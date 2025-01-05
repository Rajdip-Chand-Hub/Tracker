
using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class UserBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "users.jason");

        protected List<Users> LoadUsers()
        {
            if (!File.Exists(FilePath)) return new List<Users>();

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();
        }

        protected void SaveUsers(List<Users> users)
        {
            var json = JsonSerializer.Serialize(users);

            File.WriteAllText(FilePath, json);
        }
    }
}
