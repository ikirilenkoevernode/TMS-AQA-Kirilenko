namespace MiniAutomationToolkit.Core.Models
{
    public record UserDto
    {
        public string Name { get; init; }
        public string Email { get; init; }

        public UserDto(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Invalid name: {name}");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"Invalid email: {email}");
            }
            if (!email.Contains('@'))
            {
                throw new ArgumentException($"Invalid mail: {email}");
            }
            if (email.Contains(' '))
            {
                throw new ArgumentException($"Invalid mail: {email}");
            }   
            Name = name;
            Email = email;
        }
    }

}

