using System.Collections.Generic;

namespace MLSA.Serverless.Services
{
    public class KebapCalculatorService : IKebapCalculatorService
    {
        public List<string> GetKebaps()
        {
            return new List<string>{
                "Adana Kebap",
                "Urfa Kebap"
            };
        }
    }
}