using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class ExampleArtMedium
{
    public int Id { get; set; }

    public int? ExampleArtId { get; set; }

    public int? MediumId { get; set; }

    public virtual ExampleArt? ExampleArt { get; set; }

    public virtual Medium? Medium { get; set; }
}
