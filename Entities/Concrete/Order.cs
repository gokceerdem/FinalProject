using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        // veritabanı nesnesi order tablosunu temsil ediyor

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
