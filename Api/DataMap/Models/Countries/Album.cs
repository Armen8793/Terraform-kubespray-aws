using System;
using System.Collections.Generic;

namespace ApiMicroservice.DataMap.Models.Countries;

public partial class Album
{
    public int? AlbumId { get; set; }

    public string? Name { get; set; }

    public int? BandId { get; set; }

    public short? Year { get; set; }

    public virtual Band? Band { get; set; }
}
