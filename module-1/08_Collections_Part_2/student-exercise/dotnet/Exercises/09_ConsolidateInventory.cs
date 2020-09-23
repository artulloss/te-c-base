using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given two Dictionaries, Dictionary<string, int>, merge the two into a new Dictionary, Dictionary<string, int> where keys in Dictionary2,
         * and their int values, are added to the int values of matching keys in Dictionary1. Return the new Dictionary.
         *
         * Unmatched keys and their int values in Dictionary2 are simply added to Dictionary1.
         *
         * ConsolidateInventory({"SKU1": 100, "SKU2": 53, "SKU3": 44} {"SKU2":11, "SKU4": 5})
         * 	 → {"SKU1": 100, "SKU2": 64, "SKU3": 44, "SKU4": 5}
         *
         */
        public Dictionary<string, int> ConsolidateInventory(Dictionary<string, int> mainWarehouse,
            Dictionary<string, int> remoteWarehouse)
        {
            var unionWarehouse = mainWarehouse.Union(remoteWarehouse);
            Dictionary<string, int> combinedWarehouseList = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> keyValue in unionWarehouse)
            {
                if (!mainWarehouse.ContainsKey(keyValue.Key))
                    mainWarehouse[keyValue.Key] = 0;
                if (!remoteWarehouse.ContainsKey(keyValue.Key))
                    remoteWarehouse[keyValue.Key] = 0;
                combinedWarehouseList[keyValue.Key] = mainWarehouse[keyValue.Key] + remoteWarehouse[keyValue.Key];
            }
            return combinedWarehouseList;
        }
    }
}
