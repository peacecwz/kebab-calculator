using System.Linq;
using MLSA.KebabCalculator.Functions.Exceptions;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.HealthRules.Rules
{
    public class BlackPaperHealthRule : IHealthRule
    {
        public static string MaterialName = "ground black pepper";

        public void Execute(CalculateKebabRequest request)
        {
            var material = request.Materials.FirstOrDefault(m => m.Name == MaterialName);
            if (material == null)
            {
                throw new InvalidMaterialException(MaterialName);
            }

            double alertConditionValue = material.Amount / request.KebabMeters;

            if (alertConditionValue > 100)
            {
                material.Notice = "It's too pain. Please careful when eating!";
            }
        }
    }
}