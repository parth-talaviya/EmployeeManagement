namespace UserManagement.Domain.Dto;

public class JwtConnectionOptionsDto
{
    [Required] public string? Key { get; set; }

    [Required] public string? Issuer { get; set; }

    [Required] public string? Audience { get; set; }
}