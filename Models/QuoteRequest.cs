using System;
using System.Collections.Generic;

namespace MCS.Models;

public partial class QuoteRequest
{
    public string RequestId { get; set; } = null!;

    public int? CustomerId { get; set; }

    public DateOnly? MovingDate { get; set; }

    public string? PickupLocation { get; set; }

    public string? DropoffLocation { get; set; }

    public virtual Customer? Customer { get; set; }
}
