using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Client
{
    public int Id { get; set; }

    public string? ClientName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();
}
