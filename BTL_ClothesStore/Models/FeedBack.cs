using System;
using System.Collections.Generic;

namespace BTL_ClothesStore.Models;

public partial class FeedBack
{
    public int FeedBackId { get; set; }

    public int AccountId { get; set; }

    public string? FeedBackContent { get; set; }

    public virtual Account Account { get; set; } = null!;
}
