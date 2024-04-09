namespace UserManagement.Domain.Models.User;

public sealed class UserRole
{
    public int Id { get; set; }

    [AsParameter] public int UserId { get; set; }

    [AsParameter] public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public string RoleName { get; set; }
}