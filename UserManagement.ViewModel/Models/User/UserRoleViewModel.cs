namespace UserManagement.ViewModel.Models.User;

public sealed class UserRoleViewModel
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public string RoleName { get; set; }
}