using System.Linq;
using MLSA.KebabCalculator.Functions.Exceptions;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.HealthRules.Rules
{
    public class GarlicHealthRule : IHealthRule
    {
        public static string MaterialName = "cloves garlic (minced)";
        public void Execute(CalculateKebabRequest request)
        {
            var material = request.Materials.FirstOrDefault(m => m.Name == MaterialName);
            if (material == null)
            {
                throw new InvalidMaterialException(MaterialName);
            }

            // TODO (peacecwz): Implement health rule
        }
    }
}