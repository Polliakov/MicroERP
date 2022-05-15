using BL.DataProviders;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class WarehouseEntryService
    {
        private readonly DataProvider<ProductInWarehouse> dataProvider = new DataProvider<ProductInWarehouse>();

        public void IncreaseCount(IEnumerable<IProductEntry> pickingEntries, Warehouse warehouse)
        {
            var warehouseEntries = dataProvider.GetDbSet();
            foreach (var pickingEntry in pickingEntries)
            {
                var warehouseEntry = warehouseEntries.FirstOrDefault(entry =>
                                     entry.Warehouse.Id == warehouse.Id &&
                                     entry.Product.Id == pickingEntry.Product.Id);

                if (warehouseEntry is null)
                {
                    warehouseEntry = new ProductInWarehouse
                    {
                        Warehouse = warehouse,
                        Product = pickingEntry.Product,
                        Count = pickingEntry.Count,
                    };
                    dataProvider.Add(warehouseEntry);
                }
                else
                {
                    warehouseEntry.Count += pickingEntry.Count;
                }
            }
        }

        public void DecreaseCount(IEnumerable<IProductEntry> productEntries, Warehouse warehouse)
        {
            throw new NotImplementedException();
        }
    }
}
