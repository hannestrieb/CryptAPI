using Xunit;
using CryptAPI; // refererar till API-projektet

namespace CryptAPI.Tests;

public class TextEncryptorTests
{
    [Fact]
    public void TestEncrypt()
    {
        var encryptor = new TextEncryptor();
        string result = encryptor.Encrypt("Hello", 3);
        Assert.Equal("Khoor", result);
    }

    [Fact]
    public void TestDecrypt()
    {
        var encryptor = new TextEncryptor();
        string result = encryptor.Decrypt("Khoor", 3);
        Assert.Equal("Hello", result);
    }
}
