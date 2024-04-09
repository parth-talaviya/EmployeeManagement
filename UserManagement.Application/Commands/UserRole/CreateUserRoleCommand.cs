namespace UserManagement.Application.Commands.UserRole;

public sealed record CreateUserRoleCommand(AddUserRoleViewModel AddUserRoleViewModel) : IRequest<AddUserRoleViewModel>;