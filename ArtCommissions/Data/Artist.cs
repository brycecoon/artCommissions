using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Artist
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Aboutme { get; set; }

    public byte[]? Profilepic { get; set; }

    public virtual ICollection<CommissionExample> CommissionExamples { get; set; } = new List<CommissionExample>();

    public virtual ICollection<CommissionRequest> CommissionRequests { get; set; } = new List<CommissionRequest>();

    public virtual ICollection<Social> Socials { get; set; } = new List<Social>();
}
