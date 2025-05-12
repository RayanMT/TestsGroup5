namespace ExamSystemApp
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // "Student" or "Teacher"
        public string Password { get; set; }
    }
}
