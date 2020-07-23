using System.Dynamic;

namespace SiteCalculator.Services.Models.Sites
{
    public interface IDevelopmentSite
    {
        decimal SiteArea { get; }
        decimal SitePerimeter { get; }
        dynamic Metrics();
    }
    
    
    public abstract class DevelopmentSite: IDevelopmentSite
    {
        private decimal Length { get; set; }
        private decimal Width { get; set; }

        protected DevelopmentSite(decimal width, decimal length)
        {
            Length = length;
            Width = width;
            Output = new ExpandoObject();
        }
        public decimal SiteArea =>  Length * Width;
        public decimal SitePerimeter =>  (Length + Width) * 2;
        protected dynamic Output { get; }

        public virtual dynamic Metrics()
        {
            Output.SiteArea = SiteArea;
            Output.SitePerimeter = SitePerimeter;
            return Output;
        }
    }
    
   public interface IDevelopmentSite<TSiteConfiguration> 
    {
        TSiteConfiguration SiteConfig { get; set; }
        decimal Area { get; }
        decimal Perimeter { get; }

    }

    

    public abstract class DevelopmentSite<TSiteConfiguration>: IDevelopmentSite<TSiteConfiguration>
    {
        private decimal Length { get; set; }
        private decimal Width { get; set; }

        protected DevelopmentSite(decimal width, decimal length)
        {
            Length = length;
            Width = width;
            Output = new ExpandoObject();
            
        }
        public TSiteConfiguration SiteConfig { get; set; }
        public decimal Area =>  Length * Width;
        public decimal Perimeter =>  (Length + Width) * 2;
        protected dynamic Output { get; set; }

        protected virtual void Metrics()
        {
            Output.Area = Area;
            Output.Perimeter = Perimeter;
        }
    }
    
}