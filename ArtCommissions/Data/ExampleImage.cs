using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class ExampleImage
{
    public int Id { get; set; }

    public int? CommissionExampleId { get; set; }

    public bool? IsInCarousel { get; set; }

    public byte[]? Image { get; set; }

    public virtual CommissionExample? CommissionExample { get; set; }
}
