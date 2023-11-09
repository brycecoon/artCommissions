using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class ExampleArt
{
    public int Id { get; set; }

    public int? CommissionId { get; set; }

    public byte[]? Image { get; set; }

    public virtual Commission? Commission { get; set; }

    public virtual ICollection<ExampleArtMedium> ExampleArtMedia { get; set; } = new List<ExampleArtMedium>();

    public virtual ICollection<ExampleArtType> ExampleArtTypes { get; set; } = new List<ExampleArtType>();
}
