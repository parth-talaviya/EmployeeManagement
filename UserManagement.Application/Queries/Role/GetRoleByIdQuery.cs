namespace UserManagement.Application.Queries.Role;

public sealed record GetRoleByIdQuery(int Id) : IRequest<RoleViewModel>;