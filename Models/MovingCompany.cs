using System;
using System.Collections.Generic;

namespace MCS.Models;

public partial class MovingCompany
{
    public string CompanyName { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
