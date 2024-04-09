namespace UserManagement.Domain.Models.ContactOrganization
{
    [AsParameter]
    public sealed class GetAllContactModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SearchText { get; set; }

        public string SortColumn { get; set; }

        public string SortOrder { get; set; }
    }
}