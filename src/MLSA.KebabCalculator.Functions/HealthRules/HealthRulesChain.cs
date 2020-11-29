using System.Collections.Generic;
using MLSA.KebabCalculator.Functions.HealthRules.Rules;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.HealthRules
{
    public class HealthRulesChain : IHealthRulesChain
    {
        private readonly List<IHealthRule> _healthRules;

        public HealthRulesChain()
        {
            _healthRules = new List<IHealthRule>()
            {
                new BlackPaperHealthRule(),
                new CuminHealthRule(),
                new GarlicHealthRule(),
                new GroundBeefHealthRule(),
                new GroundLambHealthRule(),
                new OnionHealthRule(),
                new RedPaperHealthRule(),
                new SaltHealthRule(),
                new SumacHealthRule()
            };
        }

        public void Execute(CalculateKebabRequest request)
        {
            _healthRules.ForEach(rule => rule.Execute(request));
        }
    }
}