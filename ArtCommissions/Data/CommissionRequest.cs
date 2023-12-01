using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class CommissionRequest
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? CommissionType { get; set; }

    public int? ArtistId { get; set; }

    public string? Details { get; set; }

    public string? AcceptedStatus { get; set; } = "PENDING";

    public string? CompletionStatus { get; set; }

    public decimal? CommissionCost { get; set; }

    public decimal? AmmountAlreadyPaid { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual ICollection<ReferenceImage> ReferenceImages { get; set; } = new List<ReferenceImage>();
}
