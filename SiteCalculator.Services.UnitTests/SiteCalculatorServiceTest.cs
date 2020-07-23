using System.Collections.Generic;
using SiteCalculator.Services.Models;
using SiteCalculator.Services.Models.Configurations;
using SiteCalculator.Services.Models.Sites;
using SiteCalculator.Services.Models.ValueObjects;
using Xunit;

namespace SiteCalculator.Services.UnitTests
{
    public class SiteCalculatorServiceTest
    {
        public static IEnumerable<object[]> DevelopmentSiteGenerator()
        {
            
            yield return new object[]
            {
                new ApartmentSite(50,1000,new ApartmentConfiguration(5,new Percent(60),70 )) 
            };
            yield return new object[]
            {
                new CommercialSite(50,1000,new CommercialConfiguration(5,new Percent(80),40,30 )),  
            };
            yield return new object[]
            {
                new MixedSite(50,1000,new MixedConfiguration(5,new Percent(90),70, 30, 60, 70 )),  
            };
            yield return new object[]
            {
                new SubDivisionSite(50,1000,new SubDivisionConfiguration(new Percent(80), 300)),  
            };
        }

        public static IEnumerable<object[]> InputModelGenerator()
        {
            yield return new object[]
            {
                new InputModel
                {
                    Length = 500,
                    Width = 100,
                    site_config = new ConfigModel{avg_apt_area = 70, development_type = DevelopmentType.apartment,num_storeys = 5,site_coverage = 70}
                }  
            };
        }

        
        [Theory]
        [MemberData(nameof(DevelopmentSiteGenerator))]
        public void CalculateMetrics_Should_Calculate_Any_Development_Site(IDevelopmentSite developmentSite)
        {
            var siteCalculatorService = new SiteCalculatorService();
            var output = siteCalculatorService.CalculateMetrics(developmentSite);
            Assert.NotNull(output);
            Assert.NotNull(output.SiteArea);
            Assert.Equal(50000,output.SiteArea);
            Assert.NotNull(output.SitePerimeter);
            Assert.Equal(2100,output.SitePerimeter);
            if (developmentSite is SubDivisionSite)
            {
                Assert.NotNull(output.NumberOfLots);
            }
            else
            {
                Assert.NotNull(output.BuildingGfa);
                Assert.NotNull(output.BuildingFootPrint);
            }
        }
        
        [Theory]
        [MemberData(nameof(InputModelGenerator))]
        public void CalculateMetrics_By_InputModel_Should_Calculate_Any_Development_Site(InputModel inputModel)
        {
            var siteCalculatorService = new SiteCalculatorService();
            var output = siteCalculatorService.CalculateMetrics(inputModel);
            Assert.NotNull(output);
            Assert.NotNull(output.SiteArea);
            Assert.Equal(50000,output.SiteArea);
            Assert.NotNull(output.SitePerimeter);
            Assert.Equal(1200,output.SitePerimeter);
        }
    }
}