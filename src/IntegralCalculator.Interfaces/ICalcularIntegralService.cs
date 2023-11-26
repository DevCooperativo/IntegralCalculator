namespace IntegralCalculator.Interfaces;
public interface ICalcularIntegralService
{
    public decimal Funcao(string expression, decimal x);
    decimal MetodoDeSimpson(decimal a, decimal b, int n, string funcao);
}
