namespace UserManagement.Application.Handlers.User;

public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userService.CreateUserAsync(request.CreateUserViewModel, cancellationToken)
            .ConfigureAwait(false);

        var viewModel = new CreateUserViewModel
        {
            Id = userId,
            Name = request.CreateUserViewModel.Name,
            Password = request.CreateUserViewModel.Password,
            Email = request.CreateUserViewModel.Email,
            ImageURL = request.CreateUserViewModel.ImageURL,
            City = request.CreateUserViewModel.City,
            PhoneNumber = request.CreateUserViewModel.PhoneNumber
        };
        return viewModel;
    }
}