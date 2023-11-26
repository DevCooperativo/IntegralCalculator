using IntegralCalculator.DTO;
namespace IntegralCalculator.Interfaces;
public interface ICalcularIntegralService
{
    decimal Funcao(string expression, decimal x);
    Dados MetodoDeSimpson(decimal a, decimal b, int n, string funcao);
    Dados MetodoDoPontoMedio(decimal a, decimal b, int n, string funcao);
    Dados MetodoDoTrapezio(decimal a, decimal b, int n, string funcao);
}
