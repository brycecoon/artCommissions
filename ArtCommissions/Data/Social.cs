using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Social
{
    public int Id { get; set; }

    public int? ArtistId { get; set; }

    public string? Link { get; set; }

    public string? Site { get; set; }

    public virtual Artist? Artist { get; set; }
}
