namespace UserManagement.Application.Commands.User;

public sealed record DeleteUserCommand(int Id) : IRequest<UserViewModel?>;