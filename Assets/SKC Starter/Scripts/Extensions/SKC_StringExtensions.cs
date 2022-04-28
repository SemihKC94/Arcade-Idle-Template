using UnityEngine;

/// <summary>
/// This class contains extensions to the string type.
/// </summary>
public static class SKC_StringExtensions
{
    /// <summary>
    /// Adds random text at the end of a string.
    /// This is an extension to the string.
    /// </summary>
    /// <returns>Enlarged text with random symbols at the end.</returns>
    /// <param name="s">String.</param>
    /// <param name="amount">Amount of new symbols.</param>
    public static string AddRandomText(this string s, int amount)
    {
        return s + GenerateRandomText(amount);
    }

    /// <summary>
    /// Generates random text with provided length.
    /// This is just helper.
    /// </summary>
    /// <returns>Random text with provided length.</returns>
    /// <param name="length">Length of generated text.</param>
    public static string GenerateRandomText(int length)
    {
        string s = string.Empty;

        for (int i = 0; i < length; i++)
        {
            // Add random symbol ASCII (A-Z)
            s += (char)Random.Range(65, 91);
        }

        return s;
    }
}
