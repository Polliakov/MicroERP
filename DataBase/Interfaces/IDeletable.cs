using System;

namespace DataBase.Interfaces
{
    public interface IDeletable
    {
        DateTime? Deleted { get; set; }
    }
}
