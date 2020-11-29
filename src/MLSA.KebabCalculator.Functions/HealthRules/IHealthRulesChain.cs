using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.HealthRules
{
    public interface IHealthRulesChain
    {
        void Execute(CalculateKebabRequest request);
    }
}