namespace UserManagement.Application.Commands.User;

public sealed record EditUserCommand(UserUpdateProfileViewModel UserUpdateProfileViewModel)
    : IRequest<UserUpdateProfileViewModel>;