using CryptAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var encryptor = new TextEncryptor();

//Encrypt endpoint
app.MapGet("/encrypt", (string text = "Hello", int shift = 3) =>
{
    if (string.IsNullOrEmpty(text))
        return Results.BadRequest("Text parameter is required");
    if (shift < 1 || shift > 25)
        return Results.BadRequest("Shift amount must be between 1 and 25");
    
    var encrypted = encryptor.Encrypt(text, shift);
    return Results.Ok(new { original = text, encrypted, shift });
});

//Decrypt endpoint
app.MapGet("/decrypt", (string text = "Khoor", int shift = 3) =>
{
    if (string.IsNullOrEmpty(text))
        return Results.BadRequest("Text parameter is required");
    if (shift < 1 || shift > 25)
        return Results.BadRequest("Shift amount must be between 1 and 25");
    
    var decrypted = encryptor.Decrypt(text, shift);
    return Results.Ok(new { original = text, decrypted, shift });
});

app.Run();
