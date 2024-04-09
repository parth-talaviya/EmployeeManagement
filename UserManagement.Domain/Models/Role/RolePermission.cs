namespace UserManagement.Domain.Models.Role;

[AsParameter]
public sealed class RolePermission
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Permission { get; set; }

    public bool IsActive { get; set; }
}