namespace UserManagement.Application.Commands.User;

public sealed record CreateUserCommand(CreateUserViewModel CreateUserViewModel) : IRequest<CreateUserViewModel>;