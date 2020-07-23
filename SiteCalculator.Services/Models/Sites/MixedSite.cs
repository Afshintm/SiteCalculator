using SiteCalculator.Services.Models.Configurations;

namespace SiteCalculator.Services.Models.Sites
{
    public class MixedSite: NewBuildingSite<IMixedConfiguration>
    {
        public MixedSite(decimal width, decimal length,IMixedConfiguration siteConfiguration) : base(width, length)
        {
            SiteConfiguration = siteConfiguration;
        }

        private decimal ResidentialGfa => BuildingGfa * SiteConfiguration.ResidentialMix;

        private decimal CommercialGfa => BuildingGfa * SiteConfiguration.CommercialMix;

        private decimal RetailGfa =>  BuildingGfa * SiteConfiguration.RetailMix;

        private int NumberOfApartments => (int)ResidentialGfa / (int)SiteConfiguration.Avg_apt_area;
        public override dynamic Metrics()
        {
            base.Metrics();
            Output.CommercialGfa = CommercialGfa;
            Output.RetailGfa = RetailGfa;
            Output.NumberOfApartments = NumberOfApartments;
            return Output;
        }

    }
}