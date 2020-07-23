using Newtonsoft.Json;
using SiteCalculator.Services.Models;
using SiteCalculator.Services.Models.Configurations;
using SiteCalculator.Services.Models.Sites;
using SiteCalculator.Services.Models.ValueObjects;
using Xunit;

namespace SiteCalculator.Services.UnitTests
{
    public class DevelopmentSiteTests
    {
        
        [Theory]
        [InlineData(50,100,90,300)]
        public void Should_Calculate_Building_Metrics_For_All_SubDivisionSite_Type(decimal width, decimal length, decimal siteCoverage, decimal avgLotSize)
        { 
            var subDivisionConfigurationStub = new SubDivisionConfiguration(new Percent(siteCoverage), avgLotSize); 
            var subDivisionSite = new SubDivisionSite(width,length,subDivisionConfigurationStub);
            var output = subDivisionSite.Metrics();
            Assert.Equal(5000m,subDivisionSite.SiteArea);
            Assert.Equal(300m,subDivisionSite.SitePerimeter);
            
            
            Assert.NotNull(output);
            Assert.Equal(15m,output.NumberOfLots);
            
        }

        [Fact]
        public void Should_Be_Able_To_Read_Input_Json()
        {
            var data = @"{""width"": 50,
            ""length"": 100,
            ""site_config"": {
                ""num_storeys"": 3,
                ""site_coverage"": 70,
                ""development_type"": ""apartment"",
                ""avg_apt_area"": 74
            }
            }";
            var inputModel = JsonConvert.DeserializeObject<InputModel>(data);
            Assert.NotNull(inputModel);
        }
        
        [Fact]
        public void Should_Be_Able_To_Read_Input_Json_Apartment_And_Calculate_Metrics()
        {
            var data = @"{""width"": 50,
            ""length"": 100,
            ""site_config"": {
                ""num_storeys"": 3,
                ""site_coverage"": 70,
                ""development_type"": ""apartment"",
                ""avg_apt_area"": 74
            }
            }";
            var inputModel = JsonConvert.DeserializeObject<InputModel>(data);
            Assert.NotNull(inputModel);
            var apartment = inputModel.ToDevelopmentSite();
            var output = apartment.Metrics();
            Assert.NotNull(output);
            Assert.Equal(5000m, output.SiteArea);
            Assert.Equal(300m, output.SitePerimeter);
            
            Assert.Equal(3500m, output.BuildingFootPrint);
            Assert.Equal(10500m, output.BuildingGfa);
            Assert.Equal(141, output.NumberOfApartment);
        }
    }
}