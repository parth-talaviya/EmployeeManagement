namespace UserManagement.Application.Queries.User;

public sealed record GetUserByIdQuery(int Id) : IRequest<UserViewModel>;