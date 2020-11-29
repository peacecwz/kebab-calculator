using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.HealthRules
{
    public interface IHealthRule
    {
        void Execute(CalculateKebabRequest request);
    }
}