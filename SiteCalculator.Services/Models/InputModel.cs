namespace SiteCalculator.Services.Models
{
    public class InputModel
    {
        public decimal Width { get; set; }
        
        public decimal Length { get; set; }
        public ConfigModel site_config { get; set; }
    }
}