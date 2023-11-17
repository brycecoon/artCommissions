using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class ReferenceImage
{
    public int Id { get; set; }

    public int? CommissionRequestId { get; set; }

    public byte[]? Image { get; set; }

    public virtual CommissionRequest? CommissionRequest { get; set; }
}
