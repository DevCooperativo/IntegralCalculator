using AngouriMath;
using System.Text.RegularExpressions;
using IntegralCalculator.Interfaces;
namespace IntegralCalculator.Services.Helper;
public static class ExtensionHelper
{
    public static decimal CalculateFormulas(this string formule, IFormuleCalculator model)
    {
        String pattern = @"([A-Z]|[a-z])+([A-z]|[a-z]|\d|_)*";

        List<string> operacoes = new List<string>{ "sqrt", "sin", "cos", "tan", "arcsin", "arccos", "arctan" };

        String output = String.Join(",",
            Regex.Matches(formule, pattern)
            .OfType<Match>().Where(item => !operacoes.Contains(item.ToString()))
            .Select(item => item.Value));
        Console.WriteLine("\n" + output + "\n");
        int i = 0;
        if (!String.IsNullOrEmpty(output))
        {
            output.Split(',').ToList().ForEach(item =>
            {
                formule = formule.Replace(item, "{" + i.ToString() + "}");
                i++;
            });
            Console.WriteLine("\n" + formule + "\n");
            var varableArray = output.Split(',');
            Object[] prms = new Object[varableArray.Length];
            var index = 0;
            varableArray.ToList().ForEach(prm =>
            {
                prms[index] = model[prm];
                index++;
            });
            formule = String.Format(formule, prms);
        }
        formule = Regex.Replace(formule, @",", ".");
        Console.WriteLine("\n" + formule + "\n");
        Entity expr = formule;
        return (decimal)expr.EvalNumerical();
    }
}