### .NET Core RFC2898 Password Encryption Sample

``` console
RFC2898 Password Encryption
---------------------------
Input your password : Root!123456@

Your password    : Root!123456@
Salt password    : Lwr2bxc2rkYQCruehi/oJ2HjkHCghLLVaFMxmNauJAECaZMcu0OUdlTg/HqkQXKyQjrzCDAVh7UVYQ5/heDmtQ==
Encoded password : CIxVYPyeirpHPpPw1LwZEZhGnIbbjBeUqwM/yY9k+pbmECfPDrHZkteWNorptMjRf9di4HfQsEFO0IPi6JcU7Q==
```

``` csharp
public static string CreateSaltPassword()
{
    var saltBytes = new byte[64];
    new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);

    return Convert.ToBase64String(saltBytes);
}
```

``` csharp
public static string EncodePassword(string password, string passwordSalt)
{
    var bytePassword     = Encoding.Unicode.GetBytes(password);
    var bytePasswordSalt = Convert.FromBase64String(passwordSalt);

    var byteRfc2898DeriveBytes = new Rfc2898DeriveBytes(bytePassword, bytePasswordSalt, 1000, HashAlgorithmName.SHA256);
    var rfcHash                = byteRfc2898DeriveBytes.GetBytes(64);

    return Convert.ToBase64String(rfcHash);
}
```
