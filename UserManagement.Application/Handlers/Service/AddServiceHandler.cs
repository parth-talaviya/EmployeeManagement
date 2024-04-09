namespace UserManagement.Application.Handlers.Service;

public sealed class AddServiceHandler : IRequestHandler<AddServiceCommand, AddServiceViewModel?>
{
    private readonly IServiceService _serviceDetailService;

    public AddServiceHandler(IServiceService serviceDetailService)
    {
        _serviceDetailService = serviceDetailService;
    }

    public Task<AddServiceViewModel?> Handle(AddServiceCommand addServiceCommand,
        CancellationToken cancellationToken)
    {
        return _serviceDetailService.AddServiceAsync(addServiceCommand.AddServiceModel, cancellationToken);
    }
}