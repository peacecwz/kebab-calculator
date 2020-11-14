using System.Collections.Generic;
using System.Linq;
using MLSA.KebabCalculator.Functions.Models;

namespace MLSA.KebabCalculator.Functions.Services
{
    public class KebabServices : IKebabServices
    {
        private readonly List<KebabMaterial> _kebapMaterials;

        public KebabServices()
        {
            _kebapMaterials = new List<KebabMaterial>()
            {
                new KebabMaterial()
                {
                    Name = "Dana Kıyma",
                    Amount = 350,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial()
                {
                    Name = "Kuzu Kıyma",
                    Amount = 300,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial()
                {
                    Name = "Diş sarmısak",
                    Amount = 1,
                    AmountType = AmountType.Piece
                },
                new KebabMaterial()
                {
                    Name = "Kuru Soğan",
                    Amount = 2,
                    AmountType = AmountType.Piece
                },
                new KebabMaterial()
                {
                    Name = "Pul biber",
                    Amount = 5,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial()
                {
                    Name = "Karabiber",
                    Amount = 5,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial()
                {
                    Name = "Acı salça",
                    Amount = 25,
                    AmountType = AmountType.Gram
                },
                new KebabMaterial()
                {
                    Name = "Maydonoz",
                    Amount = 0.5,
                    AmountType = AmountType.Piece
                },
                new KebabMaterial()
                {
                    Name = "Sıvı Yağ",
                    Amount = 60,
                    AmountType = AmountType.Piece
                },
            };
        }

        public List<KebabMaterial> GetFoodMaterials(int peopleCount)
        {
            return _kebapMaterials.Select(material => new KebabMaterial()
            {
                AmountType = material.AmountType,
                Name = material.Name,
                Amount = material.Amount * peopleCount,
                Notice = ""
            }).ToList();
        }
    }

    public interface IKebabServices
    {
        List<KebabMaterial> GetFoodMaterials(int peopleCount);
    }
}