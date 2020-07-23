using SiteCalculator.Services.Models.Configurations;

namespace SiteCalculator.Services.Models.Sites
{
    public class SubDivisionSite: DevelopmentSite
    {
        private readonly ISubDivisionConfiguration _subDivisionConfiguration;

        public SubDivisionSite(decimal width, decimal length, ISubDivisionConfiguration subDivisionConfiguration) : base(width, length)
        {
            _subDivisionConfiguration = subDivisionConfiguration;
        }

        public override dynamic Metrics()
        {
            base.Metrics();
            Output.NumberOfLots = SiteArea * _subDivisionConfiguration.Site_coverage / _subDivisionConfiguration.Avg_Lot_Size;
            return Output;
        }
    }
}