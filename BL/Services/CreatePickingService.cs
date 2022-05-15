using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class CreatePickingService
    {
        public CreatePickingService(AuthenticatedUser user)
        {
            this.user = user;
        }

        private readonly AuthenticatedUser user;
        private readonly WarehouseEntryService warehouseService = new WarehouseEntryService();
        private readonly DataProvider<ProductPicking> productPickingDP = new DataProvider<ProductPicking>();

        public void Create(IEnumerable<ProductInPicking> pickingEntries, Warehouse warehouse)
        {
            warehouseService.IncreaseCount(pickingEntries, warehouse);
            CreateProductPicking(pickingEntries);          
        }      

        private void CreateProductPicking(IEnumerable<ProductInPicking> pickingEntries)
        {
            productPickingDP.Create(new ProductPicking
            {
                UserId = user.User.Id,
                Items = pickingEntries.ToList(),
                Timestamp = System.DateTime.Now,
            });
        }
    }
}
