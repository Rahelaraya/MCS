using System;
using System.Collections.Generic;

namespace MCS.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Service? Service { get; set; }
}
