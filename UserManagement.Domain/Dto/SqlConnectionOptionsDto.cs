namespace UserManagement.Domain.Dto;

public class SqlConnectionOptionsDto
{
    [Required] public string? ConnectionString { get; set; }
}