using System;
using System.Collections.Generic;

namespace MCS.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual MovingCompany? CompanyNameNavigation { get; set; }
}
