using System.Text.Json.Serialization;

namespace _529Homework.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UsersBookmarks> UsersBookmarks { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}