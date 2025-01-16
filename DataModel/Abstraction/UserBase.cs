
using DataModel.Model;
using System.Text.Json;

namespace DataModel.Abstractions
{
    public class UserBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "users.json"); // Creating a jason file

        protected List<Users> LoadUsers() // Method to load list of debts from JSON file
        {
            if (!File.Exists(FilePath)) return new List<Users>(); // Checking if the file exists

            var json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>(); // Deserializes the JSON string into a list
        }

        protected void SaveUsers(List<Users> users) // Method to load list of debts from JSON file
        {
            var json = JsonSerializer.Serialize(users); // Serializes the list into JSON string

            File.WriteAllText(FilePath, json); // Write the JSON string to file
        }
    }
}
