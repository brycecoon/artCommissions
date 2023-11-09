using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class CommissionType
{
    public int Id { get; set; }

    public int? CommissionId { get; set; }

    public int? CtypeId { get; set; }

    public virtual Commission? Commission { get; set; }

    public virtual Ctype? Ctype { get; set; }
}
