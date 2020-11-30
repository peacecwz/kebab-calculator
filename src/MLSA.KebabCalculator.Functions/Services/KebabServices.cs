using System;
using System.Collections.Generic;
using System.Linq;
using MLSA.KebabCalculator.Functions.HealthRules;
using MLSA.KebabCalculator.Functions.HealthRules.Rules;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.Services
{
    public class KebabCalculationResult
    {
        public int PeopleCount { get; set; }
        public double MeterSize { get; set; }
        public List<KebabMaterial> KebabMaterials { get; set; }
    }

    public class KebabServices : IKebabServices
    {
        private readonly List<KebabMaterial> _kebabMaterials;
        private static readonly double DefaultKebapCentiMeterSize = 300;
        private static readonly int DefaultPeopleCount = 12;

        private readonly IHealthRulesChain _healthRulesChain;

        public KebabServices(IHealthRulesChain healthRulesChain)
        {
            _healthRulesChain = healthRulesChain;
            _kebabMaterials = GetKebabMaterials();
        }

        public KebabCalculationResult GetFoodMaterialsByMeters(double meters)
        {
            var kebabMaterials = _kebabMaterials.Select(material => new KebabMaterial
            {
                AmountType = material.AmountType,
                Name = material.Name,
                Amount = (int) Math.Round((material.Amount / DefaultKebapCentiMeterSize) * (meters * 100), 2),
                Notice = ""
            }).ToList();
            var peopleCount = (int) Math.Round((DefaultPeopleCount * meters * 100) / DefaultKebapCentiMeterSize);

            _healthRulesChain.Execute(new CalculateKebabRequest()
            {
                Materials = kebabMaterials,
                KebabMeters = meters,
                PeopleCount = peopleCount
            });

            return new KebabCalculationResult
            {
                MeterSize = meters,
                PeopleCount = peopleCount,
                KebabMaterials = kebabMaterials
            };
        }

        public KebabCalculationResult GetFoodMaterialsByPeopleCount(int peopleCount)
        {
            var kebabMaterials = _kebabMaterials.Select(material => new KebabMaterial
            {
                AmountType = material.AmountType,
                Name = material.Name,
                Amount = Math.Round((material.Amount / DefaultPeopleCount) * peopleCount, 2),
                Notice = ""
            }).ToList();

            double meters = Math.Round(((peopleCount * DefaultKebapCentiMeterSize) / DefaultPeopleCount) / 100, 2);
            _healthRulesChain.Execute(new CalculateKebabRequest()
            {
                Materials = kebabMaterials,
                KebabMeters = meters,
                PeopleCount = peopleCount
            });

            return new KebabCalculationResult()
            {
                PeopleCount = peopleCount,
                KebabMaterials = kebabMaterials,
                MeterSize = meters
            };
        }

        private static List<KebabMaterial> GetKebabMaterials()
        {
            return new List<KebabMaterial>()
            {
                new KebabMaterial
                {
                    Name = GroundLambHealthRule.MaterialName,
                    Amount = 1000,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial
                {
                    Name = GroundBeefHealthRule.MaterialName,
                    Amount = 1000,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial
                {
                    Name = OnionHealthRule.MaterialName,
                    Amount = 1,
                    AmountType = AmountType.Piece
                },
                new KebabMaterial
                {
                    Name = GarlicHealthRule.MaterialName,
                    Amount = 4,
                    AmountType = AmountType.Piece
                },
                new KebabMaterial
                {
                    Name = CuminHealthRule.MaterialName,
                    Amount = 1.5,
                    AmountType = AmountType.Piece,
                    PieceType = "teaspoons"
                },
                new KebabMaterial
                {
                    Name = SumacHealthRule.MaterialName,
                    Amount = 1.5,
                    AmountType = AmountType.Piece,
                    PieceType = "teaspoons"
                },
                new KebabMaterial
                {
                    Name = SaltHealthRule.MaterialName,
                    Amount = 0.5,
                    AmountType = AmountType.Piece,
                    PieceType = "teaspoons"
                },
                new KebabMaterial
                {
                    Name = BlackPaperHealthRule.MaterialName,
                    Amount = 0.25,
                    AmountType = AmountType.Piece,
                    PieceType = "teaspoons"
                },
                new KebabMaterial
                {
                    Name = RedPaperHealthRule.MaterialName,
                    Amount = 0.25,
                    AmountType = AmountType.Piece,
                    PieceType = "teaspoons"
                },
            };
        }
    }

    public interface IKebabServices
    {
        KebabCalculationResult GetFoodMaterialsByPeopleCount(int peopleCount);
        KebabCalculationResult GetFoodMaterialsByMeters(double meters);
    }
}