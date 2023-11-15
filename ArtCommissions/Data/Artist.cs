using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class Artist
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Socials { get; set; }

    public string? Aboutme { get; set; }
}
