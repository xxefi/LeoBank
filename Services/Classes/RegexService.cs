using System.Text.RegularExpressions;
using LeoBank.Services.Interfaces;

namespace LeoBank.Services.Classes;

public class RegexService : IRegexService
{
    private readonly Dictionary<string, string> _patterns = new Dictionary<string, string>
    {
        {"Name", "^[A-Z][a-z]+$"},
        {"Surname", "^[A-Z][a-z]+$"},
        {"Login", "^[a-zA-Z0-9_-]{3,16}$"},
        {"Email", "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"},
        {"Password", @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])[A-Za-z\d!@#$%^&*()-_+=]{8,}$"},
        {"FIN", @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$"},
        {"Phone", @"^\+\d{3}\d{9}$"}
    };

    public bool IsValid(string input, string pattern)
    {
        if (_patterns.ContainsKey(pattern))
        {
            string patternName = _patterns[pattern];
            return Regex.IsMatch(input, pattern);
        }

        return false;
    }
}