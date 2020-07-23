using System.ComponentModel.DataAnnotations;
using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models.Configurations
{
    /// <summary>
    /// Configuration interface for apartment buildings
    /// </summary>
    public interface IApartmentConfiguration: IBuildingConfiguration
    {
        decimal Avg_apt_area { get;}
    }
    public class ApartmentConfiguration: SiteConfiguration,IApartmentConfiguration
    {
        public decimal Avg_apt_area { get;}

        public ApartmentConfiguration(int numStoreys , Percent siteCoverage, decimal aveAptArea) : 
            base(DevelopmentType.apartment, siteCoverage, numStoreys)
        {
            Avg_apt_area = aveAptArea;
        }
    }
}