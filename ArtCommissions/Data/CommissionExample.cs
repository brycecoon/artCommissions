using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class CommissionExample
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? CommissionType { get; set; }

    public int? ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual ICollection<ExampleImage> ExampleImages { get; set; } = new List<ExampleImage>();
}
