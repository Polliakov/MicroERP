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
            warehouseService.AddEntries(productSells, warehouse);
            CreateCheque(productSells);
        }

        private void CreateCheque(IEnumerable<ProductSell> productSells)
        {
            throw new NotImplementedException();
        }
    }
}
