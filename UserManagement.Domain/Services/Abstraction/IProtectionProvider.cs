namespace UserManagement.Domain.Services.Abstraction;

public interface IProtectionProvider
{
    string Protect(string value);

    string UnProtect(string value);
}