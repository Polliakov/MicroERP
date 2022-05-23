using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class CreatePickingService
    {
        public CreatePickingService(AuthenticatedUser user, Warehouse warehouse)
        {
            this.user = user;
            this.warehouse = warehouse;
        }

        private readonly AuthenticatedUser user;
        private readonly Warehouse warehouse;
        private readonly WarehouseEntryService warehouseService = new WarehouseEntryService();
        private readonly DataProvider<ProductPicking> productPickingDP = new DataProvider<ProductPicking>();

        public void Create(IEnumerable<ProductInPicking> pickingEntries)
        {
            warehouseService.AddEntries(pickingEntries, warehouse);
            CreateProductPicking(pickingEntries);          
        }      

        private void CreateProductPicking(IEnumerable<ProductInPicking> pickingEntries)
        {
            productPickingDP.Create(new ProductPicking
            {
                UserId = user.User.Id,
                WarehouseId = warehouse.Id,
                Items = pickingEntries.ToList(),
                Timestamp = System.DateTime.Now,
            });
        }
    }
}
