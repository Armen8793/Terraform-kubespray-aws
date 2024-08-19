using System;
using System.Collections.Generic;

namespace ApiMicroservice.DataMap.Models.Countries;

public partial class Band
{
    public int BandId { get; set; }

    public string? Name { get; set; }

    public int? Year { get; set; }
}
