using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MLSA.Serverless.Services;
using System.Collections.Generic;

namespace MLSA.Serverless
{
    public class CalculateKebap
    {
        private readonly IKebapCalculatorService _kebapCalculatorService;
        private readonly ILogger<CalculateKebap> _logger;
        public CalculateKebap(IKebapCalculatorService kebapCalculatorService, ILogger<CalculateKebap> logger)
        {
            _kebapCalculatorService = kebapCalculatorService;
            _logger = logger;
        }

        [FunctionName("GetKebaps")]
        public IActionResult GetKebaps([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "kebaps")] HttpRequest req)
        {
            return new OkObjectResult(_kebapCalculatorService.GetKebaps());
        }

        [FunctionName("GetKebapsActions")]
        public IActionResult GetActions([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "kebaps/actions")] HttpRequest req)
        {
            List<string> actions = new List<string>()
            {
                "/kebaps/actions/calculate"
            };
            return new OkObjectResult(actions);
        }

        [FunctionName("CalculateKebap")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "kebaps/actions/calculate")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
