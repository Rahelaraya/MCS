using System;
using System.Collections.Generic;

namespace MCS.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<QuoteRequest> QuoteRequests { get; set; } = new List<QuoteRequest>();
}
