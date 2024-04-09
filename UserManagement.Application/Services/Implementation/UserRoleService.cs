namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IUserRoleService))]
public sealed class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<int> AddUserRoleAsync(AddUserRoleViewModel userRoleViewModel, CancellationToken cancellationToken)
    {
        var userRoles = _mapper.Map<AddUserRoleViewModel, UserRole>(userRoleViewModel);

        return await _userRoleRepository.AddUserRoleAsync(userRoles, cancellationToken).ConfigureAwait(false);
    }

    public async Task<IEnumerable<UserRoleViewModel?>> GetUserRoleAsync(int userId, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.GetUserRoleAsync(userId, cancellationToken).ConfigureAwait(false);

        return _mapper.Map<List<UserRoleViewModel>>(userRole) ?? Enumerable.Empty<UserRoleViewModel>();
    }

    public async Task<UserRoleViewModel?> DeleteUserRoleAsync(int id, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.DeleteUserRoleAsync(id, cancellationToken).ConfigureAwait(false);

        return userRole != null ? _mapper.Map<UserRoleViewModel>(userRole) : null;
    }
}