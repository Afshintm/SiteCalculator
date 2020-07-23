using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models.Configurations
{
    /// <summary>
    /// Configuration interface for commercial buildings 
    /// </summary>
    public interface ICommercialConfiguration: IBuildingConfiguration
    {
        decimal CommercialMix { get; }
        decimal RetailMix { get; }
    }

    public class CommercialConfiguration: SiteConfiguration, ICommercialConfiguration
    {
        public decimal CommercialMix { get; }
        public decimal RetailMix { get; }
        
        public CommercialConfiguration( int numStoreys, Percent siteCoverage,decimal commercialMix, decimal retailMix) : base(DevelopmentType.commercial, siteCoverage, numStoreys)
        {
            CommercialMix = commercialMix;
            RetailMix = retailMix;
        }
    }
}