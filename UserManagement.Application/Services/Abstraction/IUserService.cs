namespace UserManagement.Application.Services.Abstraction;

public interface IUserService
{
    Task<UserUpdateProfileViewModel?> EditUserAsync(UserUpdateProfileViewModel userUpdateProfileViewModel,
        CancellationToken cancellationToken);

    Task<UserPasswordUpdateViewModel?> EditUserPasswordAsync(UserPasswordUpdateViewModel userViewModel,
        CancellationToken cancellationToken);

    Task<IEnumerable<UserViewModel>> GetAllUserAsync(CancellationToken cancellationToken);

    Task<UserViewModel?> GetUserAsync(int id, CancellationToken cancellationToken);

    Task<UserViewModel?> DeleteUserAsync(int id, CancellationToken cancellationToken);

    Task<int> CreateUserAsync(CreateUserViewModel userViewModel, CancellationToken cancellationToken);
}