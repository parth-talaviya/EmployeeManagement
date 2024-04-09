namespace UserManagement.Application.Queries.RefreshToken;

public sealed record GetRefreshTokenQuery(int Id) : IRequest<string>;