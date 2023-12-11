using AngouriMath;
using System.Text.RegularExpressions;
using IntegralCalculator.Interfaces;
namespace IntegralCalculator.Services.Helper;
public static class ExtensionHelper
{
    public static decimal CalculateFormulas(this string formule, IDictionary<string, decimal> variables)
    {
        formule = formule.Replace("x", variables["x"].ToString());
        formule = formule.Replace("e", variables["e"].ToString());
        formule = formule.Replace("pi", variables["pi"].ToString());
        formule = formule.Replace(",", ".");
        var expr = MathS.FromString(formule);

        return (decimal)expr.EvalNumerical();
    }
}