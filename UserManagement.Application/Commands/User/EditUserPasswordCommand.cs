namespace UserManagement.Application.Commands.User;

public sealed record EditUserPasswordCommand(UserPasswordUpdateViewModel UserPasswordUpdateViewModel)
    : IRequest<UserPasswordUpdateViewModel>;