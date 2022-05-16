using BL.DataProviders;
using DataBase.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class WarehouseEntryService
    {
        private readonly DataProvider<ProductInWarehouse> dataProvider = new DataProvider<ProductInWarehouse>();

        public void AddEntries(IEnumerable<IProductEntry> productEntries, Warehouse warehouse)
        {
            var warehouseEntries = dataProvider.GetData();
            foreach (var pickingEntry in productEntries)
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

        public void WriteOfEntries(IEnumerable<IProductEntry> productEntries, Warehouse warehouse)
        {
            var warehouseEntries = dataProvider.GetData();
            var PeWeMatches = productEntries.Select(pe =>
                                     (productEntry: pe,
                                      warehouseEntry: warehouseEntries.FirstOrDefault(we =>
                                                       we.Warehouse.Id == warehouse.Id &&
                                                       we.Product.Id == pe.Product.Id)
                                     ));

            foreach (var (productEntry, warehouseEntry) in PeWeMatches)
            {
                if ((warehouseEntry is null) || (productEntry.Count > warehouseEntry.Count))
                    throw new WarehouseWriteOfException(productEntry.Product, productEntry.Count,
                                                        warehouse, (warehouseEntry?.Count ?? 0));
            }

            foreach (var (productEntry, warehouseEntry) in PeWeMatches)
            {
                warehouseEntry.Count -= productEntry.Count;
            }
        }
    }
}
