using eIMIC223925.DATA.Enum;
using System;
using System.Collections.Generic;

namespace eIMIC223925.DATA.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }

        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }

        public OrderStatus Status { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Guid UserId { set; get; }
        public AppUser AppUser { get; set; } // do nó có liên kết bên class AppUser
    }
}
