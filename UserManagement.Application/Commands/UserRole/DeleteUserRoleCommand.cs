namespace UserManagement.Application.Commands.UserRole;

public sealed record DeleteUserRoleCommand(int Id) : IRequest<UserRoleViewModel>;