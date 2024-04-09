namespace UserManagement.Application.Queries.UserRole;

public sealed record GetUserRoleByIdQuery(int UserId) : IRequest<IEnumerable<UserRoleViewModel>>;