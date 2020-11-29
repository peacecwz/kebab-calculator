using System;

namespace MLSA.KebabCalculator.Functions.Exceptions
{
    public class InvalidMaterialException : Exception
    {
        public InvalidMaterialException(string materialName)
            : base($"Invalid or not found {materialName} material")
        {
        }
    }
}