using BL.DataProviders;
using BL.Security;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CreateChequeService
    {
        public CreateChequeService(AuthenticatedUser user, Warehouse warehouse)
        {
            this.user = user;
            this.warehouse = warehouse;
        }

        private readonly AuthenticatedUser user;
        private readonly Warehouse warehouse;
        private readonly WarehouseEntryService warehouseService = new WarehouseEntryService();
        private readonly DataProvider<Cheque> dataProvider = new DataProvider<Cheque>();

        public void Create(IEnumerable<ProductSell> productSells)
        {
            warehouseService.WriteOfEntries(productSells, warehouse);
            CreateCheque(productSells);
        }

        private void CreateCheque(IEnumerable<ProductSell> productSells)
        {
            var total = productSells.Aggregate(0m, (acc, ps) => acc += ps.Product.Price * ps.Count);
            dataProvider.Create(new Cheque
            {
                Items = productSells.ToList(),
                Total = total,
                UserId = user.User.Id,
                Timestamp = DateTime.Now,
            });
        }
    }
}
