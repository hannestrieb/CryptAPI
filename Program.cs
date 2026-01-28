using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Krypterings endpoint med defaultvärden på parametrarna
app.MapGet("/encrypt", (string text = "Hello", int shiftAmount = 3) =>
{
    if (string.IsNullOrEmpty(text))
        return Results.BadRequest("Text parameter is required");

    if (shiftAmount < 1 || shiftAmount > 25)
        return Results.BadRequest("Shift amount must be between 1 and 25");

    var encrypted = Encrypt(text, shiftAmount);
    return Results.Ok(new { original = text, encrypted = encrypted, shift = shiftAmount });
});

//Avkrypterings endpoint med defaultvärden på parametrarna
app.MapGet("/decrypt", (string text = "Khoor", int shiftAmount = 3) =>
{
    if (string.IsNullOrEmpty(text))
        return Results.BadRequest("Text parameter is required");

    if (shiftAmount < 1 || shiftAmount > 25)
        return Results.BadRequest("Shift amount must be between 1 and 25");

    var decrypted = Decrypt(text, shiftAmount);
    return Results.Ok(new { original = text, decrypted = decrypted, shift = shiftAmount });
});

app.Run();

string Encrypt(string text, int shiftAmount)
{
    return ShiftLetters(text, shiftAmount);
}

string Decrypt(string text, int shiftAmount)
{
    return ShiftLetters(text, -shiftAmount);
}

string ShiftLetters(string text, int shiftAmount)
{
    var result = "";

    foreach (char c in text)
    {
        if (!char.IsLetter(c))
        {
            result += c;
            continue;
        }

        char offset = char.IsUpper(c)? 'A' : 'a';
        //Engelska alfabetet, dvs endast 26 bokstäver
        char shifted = (char)(((c - offset + shiftAmount + 26) % 26) + offset);
        result += shifted;
    }

    return result;
}