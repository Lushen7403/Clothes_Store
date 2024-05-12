using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double ProductPrice { get; set; }

    public string ProductImage { get; set; } = null!;

    public string? ProductDecript { get; set; }

    public int CategoryId { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
