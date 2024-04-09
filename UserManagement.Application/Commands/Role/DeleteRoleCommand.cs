namespace UserManagement.Application.Commands.Role;

public sealed record DeleteRoleCommand(int Id) : IRequest<RoleViewModel>;