using FluentAssertions;
using MLSA.KebabCalculator.Functions.Services;
using Xunit;

namespace MLSA.KebabCalculator.Tests.Services
{
    public class KebabServicesTests
    {
        private readonly KebabServices _kebabCalculatorService;

        public KebabServicesTests()
        {
            _kebabCalculatorService = new KebabServices();
        }

        [Theory]
        [InlineData(400, 100)]
        [InlineData(12, 3)]
        [InlineData(1, 0.25)]
        public void It_should_calculate_meters_by_people_count(int peopleCount, double resultMeters)
        {
            //Arrange

            //Act
            var result = _kebabCalculatorService.GetFoodMaterialsByPeopleCount(peopleCount);

            //Assert
            result.MeterSize.Should().Be(resultMeters);
        }

        [Theory]
        [InlineData(100, 400)]
        [InlineData(3, 12)]
        [InlineData(0.25, 1)]
        public void It_should_calculate_people_count_by_meters(double meters, int peopleCount)
        {
            //Arrange

            //Act
            var result = _kebabCalculatorService.GetFoodMaterialsByMeters(meters);

            //Assert
            result.PeopleCount.Should().Be(peopleCount);
        }
    }
}