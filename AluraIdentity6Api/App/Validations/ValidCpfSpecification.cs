using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Validations.Interfaces;
using System.Text.RegularExpressions;

namespace AluraIdentity6Api.App.Validations;

public partial class ValidCpfSpecification : ISpecification<AppUser>
{
    private static int[] FirstMultipliers => [10, 9, 8, 7, 6, 5, 4, 3, 2];
    private static int[] LastMultipliers => [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

    public bool IsSatisfiedBy(AppUser entity)
    {
        var ignorableChars = IgnorableCpfCharacters();
        var cpf = entity.Cpf.Trim();

        ignorableChars.Replace(cpf, string.Empty);

        if (cpf.Length is not 11) return false;

        int firstSum = 0;
        string tmpCpf = cpf[..9];

        try
        {
            for (var i = 0; i < 9; i++)
                firstSum += int.Parse(tmpCpf[i].ToString()) * FirstMultipliers[i];

            var remainder = firstSum % 11;
            remainder = remainder >= 2 ? 11 - remainder : 0;

            var currentDigit = remainder.ToString();
            tmpCpf += currentDigit;

            int secondSum = 0;

            for (var i = 0; i < 10; i++)
                secondSum += int.Parse(tmpCpf[i].ToString()) * LastMultipliers[i];

            remainder = secondSum % 11;
            remainder = remainder >= 2 ? 11 - remainder : 0;

            var lastDigit = currentDigit + remainder.ToString();

            return cpf.EndsWith(lastDigit);
        }
        catch
        {
            return false;
        }
    }

    [GeneratedRegex("[\\.-]")]
    private static partial Regex IgnorableCpfCharacters();
}
