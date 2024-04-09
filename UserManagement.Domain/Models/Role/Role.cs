namespace UserManagement.Domain.Models.Role;

public sealed class Role
{
    public int Id { get; set; }

    [AsParameter] public string Name { get; set; }

    public bool IsActive { get; set; }
}