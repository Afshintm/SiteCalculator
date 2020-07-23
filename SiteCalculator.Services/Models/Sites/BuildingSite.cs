using SiteCalculator.Services.Models.Configurations;

namespace SiteCalculator.Services.Models.Sites
{
    public interface IBuildingSite
    {
        decimal BuildingFootPrint { get; }
        decimal BuildingGfa { get; }
    }

    public abstract class BuildingSite : DevelopmentSite, IBuildingSite
    {
        private readonly ISiteConfiguration _siteConfiguration;

        protected BuildingSite(decimal width, decimal length, ISiteConfiguration siteConfiguration) : base(width, length)
        {
            _siteConfiguration = siteConfiguration;
        }
        public virtual decimal BuildingFootPrint => SiteArea * _siteConfiguration.Site_coverage.Value;
        public virtual decimal BuildingGfa => BuildingFootPrint * _siteConfiguration.Num_storeys;
        public override dynamic Metrics()
        {
            base.Metrics();
            Output.BuildingFootPrint = BuildingFootPrint;
            Output.BuildingGfa = BuildingGfa;
            return Output;
        }
    }
    
    
    public interface INewBuildingSite<T>
    {
        decimal BuildingFootPrint { get; }
        decimal BuildingGfa { get; }
        T SiteConfiguration { get; set; }
    }

    public class NewBuildingSite<T> : DevelopmentSite, INewBuildingSite<T> where T: IBuildingConfiguration
    {
        protected NewBuildingSite(decimal width, decimal length) : base(width, length)
        {
            
        }
        public virtual decimal BuildingFootPrint => SiteArea * SiteConfiguration.Site_coverage.Value;
        public virtual decimal BuildingGfa => BuildingFootPrint * SiteConfiguration.Num_storeys;
        public T SiteConfiguration { get; set; }

        public override dynamic Metrics()
        {
            base.Metrics();
            Output.BuildingFootPrint = BuildingFootPrint;
            Output.BuildingGfa = BuildingGfa;
            return Output;
        }
    }
}