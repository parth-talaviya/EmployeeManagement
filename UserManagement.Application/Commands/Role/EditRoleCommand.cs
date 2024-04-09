namespace UserManagement.Application.Commands.Role;

public sealed record EditRoleCommand(UpdateRoleViewModel UpdateRoleViewModel) : IRequest<UpdateRoleViewModel>;