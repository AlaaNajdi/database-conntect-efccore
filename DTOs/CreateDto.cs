public class CreateUserDto
    {
     
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public bool IsBanned { get; set; } = false;
       

    }