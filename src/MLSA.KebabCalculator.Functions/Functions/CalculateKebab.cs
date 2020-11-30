using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MLSA.KebabCalculator.Functions.Models;
using MLSA.KebabCalculator.Functions.Services;

namespace MLSA.KebabCalculator.Functions.Functions
{
    public class CalculateKebab
    {
        private readonly IKebabServices _kebabServices;
        private readonly ILogger<CalculateKebab> _logger;

        public CalculateKebab(IKebabServices kebabServices, ILogger<CalculateKebab> logger)
        {
            _kebabServices = kebabServices;
            _logger = logger;
        }

        [FunctionName("CalculateKebab")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "kebabs/calculate")]
            HttpRequest httpRequest
        )
        {
            var request = await JsonSerializer.DeserializeAsync<CalculateKebabRequest>(httpRequest.Body);

            KebabCalculationResult result = null;

            result = request.PeopleCount > default(int)
                ? _kebabServices.GetFoodMaterialsByPeopleCount(request.PeopleCount)
                : _kebabServices.GetFoodMaterialsByMeters(request.KebabMeters);


            return new OkObjectResult(result);
        }
    }
}