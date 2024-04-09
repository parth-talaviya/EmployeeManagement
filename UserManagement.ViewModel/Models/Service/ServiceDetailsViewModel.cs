namespace UserManagement.ViewModel.Models.Service;

public sealed class ServiceDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}