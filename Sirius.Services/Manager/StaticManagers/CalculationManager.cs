using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.StaticManagers
{
    public static class CalculationManager
    {
        public static double ComputeAverage(IEnumerable<double> values)
        {
            return values.Average();
        }

        public static double ConvertScoreToRatio(double rating, double maxScore, double ratio)
        {
            double newRating = (rating / maxScore) * ratio;
            return Math.Round(newRating, 2);
        }
    }
}
