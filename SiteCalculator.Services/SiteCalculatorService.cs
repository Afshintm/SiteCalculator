using System.Collections.Generic;
using SiteCalculator.Services.Models;
using SiteCalculator.Services.Models.Sites;

namespace SiteCalculator.Services
{
    public class SiteCalculatorService
    {
        public dynamic CalculateMetrics(IDevelopmentSite developmentSite)
        {
            return developmentSite?.Metrics();
        }

        public dynamic CalculateMetrics(InputModel model)
        {
            return CalculateMetrics(model?.ToDevelopmentSite());
        }

        public IEnumerable<dynamic> CalculateMetrics(IEnumerable<InputModel> models)
        {
            if (models == null) yield break;
            foreach (var model in models)
            {
                yield return CalculateMetrics(model?.ToDevelopmentSite());
            }
        }
    }
}