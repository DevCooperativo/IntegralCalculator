using AngouriMath;
using System.Text.RegularExpressions;
using IntegralCalculator.Interfaces;
namespace IntegralCalculator.Services.Helper;
public static class ExtensionHelper
{
    public static decimal CalculateFormulas(this string formule, IDictionary<string, decimal> variables)
    {
        // String pattern = @"([A-Z]|[a-z])+([A-z]|[a-z]|\d|_)*$";

        // List<string> operacoes = new List<string>{ "sqrt", "sin", "cos", "tan", "arcsin", "arccos", "arctan", "^" };

        // String output = String.Join(",",
        //     Regex.Matches(formule, pattern)
        //     .OfType<Match>().Where(item => !operacoes.Contains(item.ToString()))
        //     .Select(item => item.Value));
        // int i = 0;
        // if (!String.IsNullOrEmpty(output))
        // {
        //     output.Split(',').ToList().ForEach(item =>
        //     {
        //         formule = formule.Replace(item, "{" + i.ToString() + "}");
        //         i++;
        //     });
        //     var varableArray = output.Split(',');
        //     Object[] prms = new Object[varableArray.Length];
        //     var index = 0;
        //     varableArray.ToList().ForEach(prm =>
        //     {
        //         prms[index] = model[prm];
        //         index++;
        //     });
        //     formule = String.Format(formule, prms);
        // }
        // formule = Regex.Replace(formule, @",", ".");

        // Entity expr = formule;
        // Entity substitutedExpr = expr.Substitute("x", Convert.ToString(model[0]));

        formule = formule.Replace("x", variables["x"].ToString());
        formule = formule.Replace("e", variables["e"].ToString());
        formule = formule.Replace("pi", variables["pi"].ToString());
        formule = formule.Replace(",", ".");
        var expr = MathS.FromString(formule);

        return (decimal)expr.EvalNumerical();
    }
}