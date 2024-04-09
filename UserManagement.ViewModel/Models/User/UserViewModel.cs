namespace UserManagement.ViewModel.Models.User;

public sealed class UserViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }

    public string ImageURL { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string RefreshToken { get; set; }

    public DateTime? RefreshTokenTime { get; set; }
}