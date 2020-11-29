using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLSA.KebabCalculator.Functions.Models
{
    public class CalculateKebabRequest
    {
        [JsonPropertyName("peopleCount")] public int PeopleCount { get; set; }
        [JsonPropertyName("kebabMeters")] public int KebabMeters { get; set; }
        [JsonPropertyName("materials")] public List<KebabMaterial> Materials { get; set; }
    }

    public class KebabMaterial
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("amount")] public double Amount { get; set; }
        [JsonPropertyName("amountType")] public AmountType AmountType { get; set; }
        [JsonPropertyName("pieceType")] public string PieceType { get; set; }
        [JsonPropertyName("notice")] public string Notice { get; set; }
    }

    public enum AmountType
    {
        Gram,
        Piece
    }
}