namespace UserManagement.Domain.Services.Implementation;

[RegisterService(typeof(IProtectionProvider))]
public sealed class ProtectionProvider : IProtectionProvider
{
    private const string SecretKey = "8CD2C1589F1C46338332874653A802C9";

    public string Protect(string value)
    {
        var toEncryptArray = Encoding.UTF8.GetBytes(value);

        using var md = MD5.Create();
        var keyArray = md.ComputeHash(Encoding.UTF8.GetBytes(SecretKey));
        md.Clear();

        using var aes = Aes.Create();
        aes.Key = keyArray;
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;

        using var cTransform = aes.CreateEncryptor();
        var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        aes.Clear();

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public string UnProtect(string value)
    {
        var toEncryptArray = Convert.FromBase64String(value);

        using var md = MD5.Create();
        var keyArray = md.ComputeHash(Encoding.UTF8.GetBytes(SecretKey));
        md.Clear();

        using var aes = Aes.Create();
        aes.Key = keyArray;
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;

        using var cTransform = aes.CreateDecryptor();
        var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        aes.Clear();
        return Encoding.UTF8.GetString(resultArray);
    }
}