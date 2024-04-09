namespace UserManagement.Domain.Models.User;

public sealed class User
{
    public int Id { get; set; }

    [AsParameter] public string Name { get; set; }

    [AsParameter] public string Password { get; set; }

    [AsParameter] public string Email { get; set; }

    [AsParameter] public string PhoneNumber { get; set; }

    [AsParameter] public string City { get; set; }

    [AsParameter] public string ImageURL { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string RefreshToken { get; set; }

    public DateTime RefreshTokenTime { get; set; }
}