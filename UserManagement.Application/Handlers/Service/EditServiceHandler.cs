namespace UserManagement.Application.Handlers.Service;

public sealed class EditServiceHandler : IRequestHandler<EditServiceCommand, EditServiceViewModel?>
{
    private readonly IServiceService _serviceDetailService;

    public EditServiceHandler(IServiceService serviceDetailService)
    {
        _serviceDetailService = serviceDetailService;
    }

    public Task<EditServiceViewModel?> Handle(EditServiceCommand editServiceCommand,
        CancellationToken cancellationToken)
    {
        return _serviceDetailService.EditServiceAsync(editServiceCommand.ServiceDetailsViewModel,
            cancellationToken);
    }
}