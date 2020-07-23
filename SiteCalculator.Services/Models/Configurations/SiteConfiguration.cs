using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models.Configurations
{
    /// <summary>
    /// This interface include the contract of site configuration 
    /// </summary>
    public interface ISiteConfiguration
    {
       
        int Num_storeys { get; set; }
        Percent Site_coverage { get; set; }
        DevelopmentType Development_type { get; set; }
        
    }
    /// <summary>
    /// The main abstract class or base class for all SiteConfiguration classes 
    /// </summary>
    public abstract class SiteConfiguration: ISiteConfiguration
    {
        public int Num_storeys { get; set; }
        public Percent Site_coverage { get; set; }
        public DevelopmentType Development_type { get; set; }

        protected SiteConfiguration(DevelopmentType developmentType, Percent siteCoverage, int numStoreys = 0)
        {
            Development_type = developmentType;
            Site_coverage = siteCoverage;
            Num_storeys = numStoreys;
        }
    }

    
    
    /// <summary>
    /// Interface for any SiteConfiguration that has any sort of building 
    /// </summary>

    public interface IBuildingConfiguration : ISiteConfiguration
    {
    }

    

    
    
    
}