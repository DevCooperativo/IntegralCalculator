namespace IntegralCalculator.Interfaces;
public interface ICalcularIntegralService
{
    decimal Funcao(string expression, decimal x);
    decimal MetodoDeSimpson(decimal a, decimal b, int n, string funcao);
    decimal MetodoDoPontoMedio(decimal a, decimal b, int n, string funcao);
    decimal MetodoDoTrapezio(decimal a, decimal b, int n, string funcao);
}
