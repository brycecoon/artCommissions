using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Medium
{
    public int Id { get; set; }

    public string? CtypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CommissionMedium> CommissionMedia { get; set; } = new List<CommissionMedium>();

    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();

    public virtual ICollection<ExampleArtMedium> ExampleArtMedia { get; set; } = new List<ExampleArtMedium>();
}
