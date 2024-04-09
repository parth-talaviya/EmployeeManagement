namespace UserManagement.Application.Commands.Role;

public sealed record CreateRoleCommand(AddRoleViewModel AddRoleViewModel) : IRequest<AddRoleViewModel>;