using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Ctype
{
    public int Id { get; set; }

    public string? CtypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();

    public virtual ICollection<ExampleArtType> ExampleArtTypes { get; set; } = new List<ExampleArtType>();
}
