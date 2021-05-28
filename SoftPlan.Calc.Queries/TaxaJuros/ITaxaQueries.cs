using System.Threading.Tasks;

namespace SoftPlan.Calc.Queries.Juros
{
    public interface ITaxaQueries
    {
        Task<decimal> ObterTaxaDeJuros();
    }
}