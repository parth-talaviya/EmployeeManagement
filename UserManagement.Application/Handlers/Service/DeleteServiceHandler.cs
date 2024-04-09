namespace UserManagement.Application.Handlers.Service;

public sealed class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, ServiceDetailsViewModel?>
{
    private readonly IServiceService _serviceDetailService;

    public DeleteServiceHandler(IServiceService serviceDetailService)
    {
        _serviceDetailService = serviceDetailService;
    }

    public async Task<ServiceDetailsViewModel?> Handle(DeleteServiceCommand request,
        CancellationToken cancellationToken)
    {
        return await _serviceDetailService.DeleteServiceAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}