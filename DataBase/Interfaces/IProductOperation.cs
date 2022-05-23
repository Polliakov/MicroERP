using DataBase.Entities;
using System;

namespace DataBase.Interfaces
{
    public interface IProductOperation
    {
        int Id { get; set; }
        int UserId { get; set; }
        int WarehouseId { get; set; }
        DateTime Timestamp { get; set; }

        User User { get; set; }
        Warehouse Warehouse { get; set; }
    }
}
