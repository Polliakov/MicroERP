using DataBase.Entities;
using System;

namespace BL.Services
{
    public class WarehouseWriteOfException : Exception
    {
        public WarehouseWriteOfException() : base() { }
        public WarehouseWriteOfException(string message, Exception innerException)
            : base(message, innerException) { }

        public WarehouseWriteOfException(
            Product product,
            int productCount,
            Warehouse warehouse,
            int leftInWarehouse)
        {
            Product = product;
            ProductCount = productCount;
            Warehouse = warehouse;
            LeftInWarehouse = leftInWarehouse;
        }

        public Product Product { get; }
        public int ProductCount { get; }
        public Warehouse Warehouse { get; }
        public int LeftInWarehouse { get; }
    }
}
