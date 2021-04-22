using System.Collections.Generic;

namespace DeviceValidation.util
{
    public static class ProductLocationUtil
    {

        private const decimal AccuracyDefaultMaxLevel = 500.0M;
        private const decimal AccuracyTrackerMaxLevel = 100.0M;
        private const decimal AccuracySmartWatchMaxLevel = 50.0M;

        private const string Tracker = "TRACKER";
        private const string SmartWatch = "SMARTWATCH";

        //Created dictionary to map the Product string with Accuracy max level, for new products we can keep adding records here
        private static Dictionary<string, decimal> ProductList = new Dictionary<string, decimal>()
        {
            {Tracker, AccuracyTrackerMaxLevel },
            {SmartWatch, AccuracySmartWatchMaxLevel }
        };

        /// <summary>
        /// Static function to get the accuracy max level based on the Product Id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public static decimal GetMaxAccuracyLevelByProductID(string ProductID)
        {
            decimal AccuracyProductMaxLevel;
            return (ProductList.TryGetValue(ProductID, out AccuracyProductMaxLevel)) ? AccuracyProductMaxLevel : AccuracyDefaultMaxLevel;
        }
    }
}
