using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models;

public partial class OrderTable
{
    public int OrderId { get; set; }

    
    public DateTime? OrderDate { get; set; }

    public double? OrderTotal { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}
