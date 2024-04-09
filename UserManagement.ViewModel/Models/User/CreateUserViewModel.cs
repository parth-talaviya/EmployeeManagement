namespace UserManagement.ViewModel.Models.User;

public sealed class CreateUserViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }

    public string ImageURL { get; set; }
}