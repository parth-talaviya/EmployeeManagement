namespace UserManagement.Application.Commands.Login;

public sealed record LoginUserCommand(LoginRequestViewModel LoginUserViewModel) : IRequest<LoginRequestViewModel>;