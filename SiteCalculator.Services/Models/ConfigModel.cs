namespace SiteCalculator.Services.Models
{
    public class ConfigModel
    {
        public int num_storeys { get; set; }
        public decimal site_coverage { get; set; }
        public DevelopmentType development_type { get; set; }
        public decimal avg_apt_area { get; set; }
        public decimal commerical_mix { get; set; }
        public decimal retail_mix { get; set; }
        public decimal residential_mix { get; set; }
        public decimal avg_lot_size { get; set; }
    }
}