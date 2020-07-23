using SiteCalculator.Services.Models.Configurations;

namespace SiteCalculator.Services.Models.Sites
{
    public class CommercialSite: BuildingSite
    {
        private decimal CommercialGfa => BuildingGfa * _commercialConfiguration.CommercialMix;
        private decimal RetailGfa => BuildingGfa * _commercialConfiguration.RetailMix;
        private readonly ICommercialConfiguration _commercialConfiguration;
        public CommercialSite(decimal width, decimal length, ICommercialConfiguration commercialConfiguration) : base(width, length, commercialConfiguration)
        {
            _commercialConfiguration = commercialConfiguration;
        }
        public override dynamic Metrics()
        {
            base.Metrics();
            Output.CommercialGfa = CommercialGfa;
            Output.RetailGfa = RetailGfa;
            return Output;
        }
    }
}