using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class CreateWriteOfService
    {
        public CreateWriteOfService(AuthenticatedUser user, Warehouse warehouse)
        {
            this.user = user;
            this.warehouse = warehouse;
        }

        private readonly AuthenticatedUser user;
        private readonly Warehouse warehouse;
        private readonly WarehouseEntryService warehouseService = new WarehouseEntryService();
        private readonly DataProvider<ProductWriteOf> dataProvider = new DataProvider<ProductWriteOf>();

        public void Create(IEnumerable<ProductInWriteOf> productEntries, string description)
        {
            warehouseService.WriteOfEntries(productEntries, warehouse);
            CreateWriteOf(productEntries, description);
        }

        private void CreateWriteOf(IEnumerable<ProductInWriteOf> productEntries, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(description);

            dataProvider.Create(new ProductWriteOf
            {
                Items = productEntries.ToList(),
                Description = description,
                UserId = user.User.Id,
                Timestamp = DateTime.Now,
            });
        }
    }
}
