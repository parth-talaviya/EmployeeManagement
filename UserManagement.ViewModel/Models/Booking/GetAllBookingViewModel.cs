namespace UserManagement.ViewModel.Models.Booking;

public sealed class GetAllBookingViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public string Service { get; set; }

    public string Location { get; set; }

    public string Organization { get; set; }

    public string PhoneNumber { get; set; }

    public string Provider { get; set; }
}