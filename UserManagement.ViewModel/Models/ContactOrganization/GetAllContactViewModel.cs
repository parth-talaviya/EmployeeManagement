namespace UserManagement.ViewModel.Models.ContactOrganization;

public sealed class GetAllContactViewModel
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string SearchText { get; set; }

    public string SortColumn { get; set; }

    public string SortOrder { get; set; }
}