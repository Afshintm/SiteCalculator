using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models.Configurations
{
    /// <summary>
    /// SubDivision Configuration including Average Lot Size 
    /// </summary>
    public interface ISubDivisionConfiguration: ISiteConfiguration
    {
        decimal Avg_Lot_Size { get;}
    }
    public class SubDivisionConfiguration: SiteConfiguration,ISubDivisionConfiguration
    {
        public decimal Avg_Lot_Size { get;}
        public SubDivisionConfiguration(Percent siteCoverage, decimal avgLotSize) : base(DevelopmentType.subdivision, siteCoverage)
        {
            Avg_Lot_Size = avgLotSize;
        }
    }
}