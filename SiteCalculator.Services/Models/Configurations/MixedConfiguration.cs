using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models.Configurations
{
    /// <summary>
    /// Configuration interface for Mix buildings 
    /// </summary>
    public interface IMixedConfiguration : ICommercialConfiguration, IApartmentConfiguration
    {
        decimal ResidentialMix { get; }
    }

    public class MixedConfiguration: SiteConfiguration,IMixedConfiguration
    {
        public decimal CommercialMix { get; }
        public decimal RetailMix { get; }
        public decimal ResidentialMix { get; }
        public decimal Avg_apt_area { get; }

        public MixedConfiguration(int numStoreys,Percent siteCoverage, decimal commercialMix, decimal retailMix,decimal residentialMix, decimal avgAptArea) 
            : base(DevelopmentType.mixed_use, siteCoverage, numStoreys)
        {
            CommercialMix = commercialMix;
            RetailMix = retailMix;
            Avg_apt_area = avgAptArea;
            ResidentialMix = residentialMix;
        }
     
    }
}