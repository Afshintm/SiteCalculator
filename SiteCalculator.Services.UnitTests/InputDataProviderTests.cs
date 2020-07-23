using SiteCalculator.Services.Models;
using Xunit;

namespace SiteCalculator.Services.UnitTests
{
    public class InputDataProviderTests
    {
        [Theory]
        [InlineData(@"
            [
                {
                    ""width"": 100,
                    ""length"": 500,
                    ""site_config"": {
                      ""num_storeys"": 0,
                      ""site_coverage"": 90,
                      ""development_type"": ""subdivision"",
                      ""avg_lot_size"": 300
                    }
                },
                {
                  ""width"": 50,
                  ""length"": 100,
                  ""site_config"": {
                    ""num_storeys"": 3,
                    ""site_coverage"": 70,
                    ""development_type"": ""apartment"",
                    ""avg_apt_area"": 74
                  }
                },
                {
                  ""width"": 250,
                  ""length"": 700,
                  ""site_config"": {
                    ""num_storeys"": 5,
                    ""site_coverage"": 70,
                    ""development_type"": ""mixed_use"",
                    ""avg_apt_area"": 74,
                    ""commerical_mix"": 20,
                    ""retail_mix"": 70,
                    ""residential_mix"": 10
                  }
                },
                {
                  ""width"": 250,
                  ""length"": 700,
                  ""site_config"": {
                    ""num_storeys"": 20,
                    ""site_coverage"": 70,
                    ""development_type"": ""commercial"",
                    ""commerical_mix"": 20,
                    ""retail_mix"": 70
                  }
                },
                {
                  ""width"": 50,
                  ""length"": 100,
                  ""site_config"": {
                    ""num_storeys"": 3,
                    ""site_coverage"": 70,
                    ""development_type"": ""apartment""
                  }
                },
                {
                  ""width"": 20,
                  ""length"": 30,
                  ""site_config"": {
                    ""num_storeys"": 2,
                    ""site_coverage"": 70,
                    ""development_type"": ""apartment"",
                    ""avg_apt_area"": 90
                  }
                },
                {
                  ""width"": 10,
                  ""length"": 50,
                  ""site_config"": {
                    ""num_storeys"": 0,
                    ""site_coverage"": 90,
                    ""development_type"": ""subdivision"",
                    ""avg_lot_size"": 450
                  }
                },
                {
                  ""width"": 10,
                  ""length"": 50,
                  ""site_config"": {
                    ""num_storeys"": 0,
                    ""site_coverage"": 90,
                    ""development_type"": ""subdivision"",
                    ""avg_lot_size"": 500
                  }
                }
            ]
        ")]
        public void GetDataList_Should_Be_Able_To_Read_Json_String_And_Provide_data(string jsonString)
        {
            var inputDataProviderProvider = new InputDataProvider();
            var dataCollection = inputDataProviderProvider.GetDataList(jsonString);
            Assert.NotNull(dataCollection);
            foreach (var item in dataCollection)
            {
                Assert.NotNull(item);
                Assert.IsType<InputModel>(item);
            }
        }
        
        [Theory]
        [InlineData(@"{
            ""width"": 100,
            ""length"": 500,
            ""site_config"": {
              ""num_storeys"": 0,
              ""site_coverage"": 90,
              ""development_type"": ""subdivision"",
              ""avg_lot_size"": 300
            }
            }")]
        [InlineData(@"{
                  ""width"": 20,
                  ""length"": 30,
                  ""site_config"": {
                    ""num_storeys"": 2,
                    ""site_coverage"": 70,
                    ""development_type"": ""apartment"",
                    ""avg_apt_area"": 90
                  }
                }")]
        [InlineData(@"{
                  ""width"": 250,
                  ""length"": 700,
                  ""site_config"": {
                    ""num_storeys"": 20,
                    ""site_coverage"": 70,
                    ""development_type"": ""commercial"",
                    ""commerical_mix"": 20,
                    ""retail_mix"": 70
                  }
                }")]
        [InlineData(@"{
                  ""width"": 250,
                  ""length"": 700,
                  ""site_config"": {
                    ""num_storeys"": 5,
                    ""site_coverage"": 70,
                    ""development_type"": ""mixed_use"",
                    ""avg_apt_area"": 74,
                    ""commerical_mix"": 20,
                    ""retail_mix"": 70,
                    ""residential_mix"": 10
                  }
                }")]
        public void GetData_Should_Be_Able_To_Read_Json_String_And_Provide_data(string jsonString)
        {
            var inputDataProviderProvider = new InputDataProvider();
            var data = inputDataProviderProvider.GetData(jsonString);
            Assert.NotNull(data);
            Assert.IsType<InputModel>(data);
        }
        
    }
}