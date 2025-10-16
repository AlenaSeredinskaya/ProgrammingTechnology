using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatehomework
{
    // class extensions
    public static class Extensions
    {
        // A generalized extension function that finds and returns the 
        // maximum element of a collection.
        public static T GetMax<T>(this IEnumerable<T> collection, Predicate<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));

            T maxItem = null;
            float maxValue = float.MinValue;

            foreach (var item in collection)
            {
                float value = convertToNumber(item);
                if (maxItem == null || value > maxValue)
                {
                    maxItem = item;
                    maxValue = value;
                }
            }

            return maxItem;
        }
    }
}
