namespace Na.TodoList.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public IEnumerable<UserRole> UserRoles { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
