using System;
using SiteCalculator.Services.Models.Configurations;
using SiteCalculator.Services.Models.Sites;
using SiteCalculator.Services.Models.ValueObjects;

namespace SiteCalculator.Services.Models
{
    public static class ExtensionsClass
    {
        /// <summary>
        /// Factory Method to instantiate different development sites 
        /// </summary>
        /// <param name="input">an InputModel instance from which development site will be instantiated</param>
        /// <returns>IDevelopmentSite</returns>
        /// <exception cref="ApplicationException">throws exception if InputModel.DevelopmentType is not valid</exception>
        public static IDevelopmentSite ToDevelopmentSite(this InputModel input)
        {
            if (input == null) return null;
            IDevelopmentSite site;
            switch (input.site_config.development_type)
            {
                case DevelopmentType.apartment:
                {
                    site =  new ApartmentSite(input.Width,input.Length,new ApartmentConfiguration(input.site_config.num_storeys, new Percent(input.site_config.site_coverage),input.site_config.avg_apt_area));
                    break;
                }
                case DevelopmentType.commercial:
                {
                    site =  new CommercialSite(input.Width,input.Length,new CommercialConfiguration(input.site_config.num_storeys, new Percent(input.site_config.site_coverage),input.site_config.commerical_mix,input.site_config.retail_mix));
                    break;
                }
                case DevelopmentType.mixed_use:
                {
                    site =  new MixedSite(input.Width,input.Length, new MixedConfiguration(input.site_config.num_storeys, new Percent(input.site_config.site_coverage),input.site_config.commerical_mix,input.site_config.retail_mix,input.site_config.residential_mix,input.site_config.avg_apt_area));
                    break;
                }
                case DevelopmentType.subdivision:
                {
                    site =  new SubDivisionSite(input.Width,input.Length, new SubDivisionConfiguration(new Percent(input.site_config.site_coverage),input.site_config.avg_lot_size));
                    break;
                }
                default:
                    throw new ApplicationException($"Not valid Development Type:{input.site_config.development_type}");

            }
            
            return site;
        }
        
    }
}