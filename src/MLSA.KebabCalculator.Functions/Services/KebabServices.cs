using System.Collections.Generic;
using System.Linq;
using MLSA.KebabCalculator.Functions.HealthRules;
using MLSA.KebabCalculator.Functions.HealthRules.Rules;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.Services
{
    public class KebabServices : IKebabServices
    {
        private readonly List<KebabMaterial> _kebabMaterials;

        public KebabServices()
        {
            _kebabMaterials = GetKebabMaterials();
        }

        public List<KebabMaterial> GetFoodMaterials(int peopleCount)
        {
            return _kebabMaterials.Select(material => new KebabMaterial()
            {
                AmountType = material.AmountType,
                Name = material.Name,
                Amount = material.Amount * peopleCount,
                Notice = ""
            }).ToList();
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
        List<KebabMaterial> GetFoodMaterials(int peopleCount);
    }
}