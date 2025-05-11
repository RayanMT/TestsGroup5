namespace project_student_tetchar
{
    public class User
    {
        public string Username { get; }
        public string PasswordHash { get; }
        public string Role { get; }

        public User(string username, string passwordHash, string role)
        {
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
