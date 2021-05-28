using System.Threading.Tasks;

namespace SoftPlan.Calc.Queries.Juros
{
    public class TaxaQueries : ITaxaQueries
    {
        
        public async Task<decimal> ObterTaxaDeJuros()
            => 0.01M;
    }
}