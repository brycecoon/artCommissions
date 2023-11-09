using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Commission
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? CtypeId { get; set; }

    public int? MediumId { get; set; }

    public string? Description { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<CommissionMedium> CommissionMedia { get; set; } = new List<CommissionMedium>();

    public virtual ICollection<CommissionType> CommissionTypes { get; set; } = new List<CommissionType>();

    public virtual Ctype? Ctype { get; set; }

    public virtual ICollection<ExampleArt> ExampleArts { get; set; } = new List<ExampleArt>();

    public virtual Medium? Medium { get; set; }
}
