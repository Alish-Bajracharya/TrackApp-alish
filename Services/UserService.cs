using System.Text.Json;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public class UserService
    {
        private readonly string _filePath;

        public UserService()
        {
            _filePath = Path.Combine(AppContext.BaseDirectory, "User.json");
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<UserModel> GetAllUsers()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<UserModel>>(jsonData) ?? new List<UserModel>();
        }

        public bool AddUser(UserModel newUser)
        {
            var users = GetAllUsers();

            // Check if the username or email already exists
            if (users.Any(u => u.Username == newUser.Username || u.Email == newUser.Email))
            {
                return false;
            }

            users.Add(newUser);
            SaveUsers(users);
            return true;
        }

        public UserModel ValidateUser(string username, string password)
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        private void SaveUsers(List<UserModel> users)
        {
            var jsonData = JsonSerializer.Serialize(users);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
