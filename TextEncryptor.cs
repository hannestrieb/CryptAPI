namespace CryptAPI;
public class TextEncryptor
{
    public string Encrypt(string text, int shiftAmount)
    {
        return ShiftLetters(text, shiftAmount);
    }

    public string Decrypt(string text, int shiftAmount)
    {
        return ShiftLetters(text, -shiftAmount);
    }

    private string ShiftLetters(string text, int shiftAmount)
    {
        var result = "";

        foreach (char c in text)
        {
            if (!char.IsLetter(c))
            {
                result += c;
                continue;
            }

            char offset = char.IsUpper(c) ? 'A' : 'a';
            char shifted = (char)(((c - offset + shiftAmount + 26) % 26) + offset);
            result += shifted;
        }

        return result;
    }
}
