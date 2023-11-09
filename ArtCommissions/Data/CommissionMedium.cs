using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class CommissionMedium
{
    public int Id { get; set; }

    public int? CommissionId { get; set; }

    public int? MediumId { get; set; }

    public virtual Commission? Commission { get; set; }

    public virtual Medium? Medium { get; set; }
}
