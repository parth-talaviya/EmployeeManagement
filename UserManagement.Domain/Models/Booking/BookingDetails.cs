namespace UserManagement.Domain.Models.Booking;

public sealed class BookingDetails
{
    public int Id { get; set; }

    public DateTime TimeSlot { get; set; }

    public DateTime Date { get; set; }

    public string Service { get; set; }

    public string Location { get; set; }

    public string Organization { get; set; }

    public string Provider { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool ConfirmBooking { get; set; }

    public bool CancelBooking { get; set; }

    public string PhoneNumber { get; set; }
}