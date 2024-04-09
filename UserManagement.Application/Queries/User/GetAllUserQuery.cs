namespace UserManagement.Application.Queries.User;

public sealed record GetAllUserQuery : IRequest<IEnumerable<UserViewModel>>;