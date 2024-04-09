namespace UserManagement.API.Controller.Booking;

public static class BookingController
{
    public static void RegisterBookingEndpoints(this WebApplication application)
    {
        var app = application.MapGroup("Booking").WithTags("Booking").RequireAuthorization("AdminPolicy");

        app.MapGet("/GetAll", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllBookingQuery = new GetAllBookingQuery();
            var bookings = await mediator.Send(getAllBookingQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(bookings);
        });

        app.MapGet("/GetAllConfirmBooking", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var getAllBookingQuery = new GetConfirmBookingQuery();
            var bookings = await mediator.Send(getAllBookingQuery, cancellationToken).ConfigureAwait(false);

            return Results.Ok(bookings);
        });

        app.MapGet("/GetSingle", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var getBookingByIdQuery = new GetBookingByIdQuery(id);
            var getProvider = await mediator.Send(getBookingByIdQuery, cancellationToken).ConfigureAwait(false);

            return getProvider;
        });

        Delegate createMethod = async (IMediator mediator, AddBookingDetailsViewModel bookingViewModel,
            CancellationToken cancellationToken) =>
        {
            var createBookingCommand = new AddBookingCommand(bookingViewModel);
            var bookingCreated = await mediator.Send(createBookingCommand, cancellationToken).ConfigureAwait(false);

            return Results.Ok(bookingCreated);
        };

        app.MapPost("/Create", createMethod).AddValidation(createMethod);


        Delegate cancelBookingMethod = async (IMediator mediator, CancelBookingViewModel cancelBookingViewModel,
            CancellationToken cancellationToken) =>
        {
            var cancelBookingCommand = new CancelBookingCommand(cancelBookingViewModel);
            var updatedBooking = await mediator.Send(cancelBookingCommand, cancellationToken).ConfigureAwait(false);

            return updatedBooking != null
                ? Results.Ok(updatedBooking)
                : Results.NotFound($"Cancel Booking ID not found.");
        };

        app.MapPut("/CancelBooking", cancelBookingMethod).AddValidation(cancelBookingMethod);

        Delegate confirmBookingMethod = async (IMediator mediator, ConfirmBookingViewModel confirmBookingViewModel,
            CancellationToken cancellationToken) =>
        {
            var cancelBookingCommand = new ConfirmBookingCommand(confirmBookingViewModel);
            var updatedBooking = await mediator.Send(cancelBookingCommand, cancellationToken).ConfigureAwait(false);

            return updatedBooking != null
                ? Results.Ok(updatedBooking)
                : Results.NotFound($"Confirm Booking ID not found."); 
        };

        app.MapPut("/ConfirmBooking", confirmBookingMethod).AddValidation(confirmBookingMethod);

        Delegate resheduleBookingMethod = async (IMediator mediator,
            ResheduleBookingViewModel resheduleBookingViewModel,
            CancellationToken cancellationToken) =>
        {
            var resheduleBookingCommand = new ResheduleBookingCommand(resheduleBookingViewModel);
            var resheduleBooking =
                await mediator.Send(resheduleBookingCommand, cancellationToken).ConfigureAwait(false);

            return resheduleBooking  != null
                ? Results.Ok(resheduleBooking)
                : Results.NotFound($"Reshedule Booking ID not found."); ;
        };

        app.MapPut("/ResheduleBooking", resheduleBookingMethod).AddValidation(resheduleBookingMethod);
    }
}