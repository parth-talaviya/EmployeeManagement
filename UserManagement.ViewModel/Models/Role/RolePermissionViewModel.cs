namespace UserManagement.ViewModel.Models.Role;

public sealed class RolePermissionViewModel
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Permission { get; set; }

    public bool IsActive { get; set; }
}