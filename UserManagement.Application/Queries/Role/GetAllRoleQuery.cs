namespace UserManagement.Application.Queries.Role;

public sealed record GetAllRoleQuery : IRequest<IEnumerable<RoleViewModel>>;