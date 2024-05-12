using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public double? Total { get; set; }


    public int? OrderId { get; set; }

    public virtual OrderTable? Order { get; set; }

    public virtual Product? Product { get; set; }

}
