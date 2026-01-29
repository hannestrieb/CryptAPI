using CryptAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var encryptor = new TextEncryptor();

// Encrypt endpoint
app.MapGet("/encrypt", (string text, int shift) =>
{
    return encryptor.Encrypt(text, shift);
});

// Decrypt endpoint
app.MapGet("/decrypt", (string text, int shift) =>
{
    return encryptor.Decrypt(text, shift);
});

app.Run();
