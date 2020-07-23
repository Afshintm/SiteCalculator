using SiteCalculator.Services.Models.Configurations;

namespace SiteCalculator.Services.Models.Sites
{
    public class ApartmentSite: BuildingSite
    {
        private readonly IApartmentConfiguration _apartmentConfiguration;
        public ApartmentSite(decimal width, decimal length, IApartmentConfiguration apartmentConfiguration) : 
            base(width, length,apartmentConfiguration)
        {
            _apartmentConfiguration = apartmentConfiguration;
        }

        int  NumberOfApartment => (int)BuildingGfa / (int)_apartmentConfiguration.Avg_apt_area;

        public override dynamic Metrics()
        {
            base.Metrics();
            Output.NumberOfApartment = NumberOfApartment;
            return Output;
        }
    }
}