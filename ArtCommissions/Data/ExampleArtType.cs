using System;
using System.Collections.Generic;

namespace ArtCommissions.Data;

public partial class ExampleArtType
{
    public int Id { get; set; }

    public int? ExampleArtId { get; set; }

    public int? CtypeId { get; set; }

    public virtual Ctype? Ctype { get; set; }

    public virtual ExampleArt? ExampleArt { get; set; }
}
