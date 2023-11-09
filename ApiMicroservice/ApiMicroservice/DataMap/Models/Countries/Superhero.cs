using System;
using System.Collections.Generic;

namespace ApiMicroservice.DataMap.Models.Countries;

public partial class Superhero
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Align { get; set; }

    public string? Eye { get; set; }

    public string? Hair { get; set; }

    public string? Gender { get; set; }

    public int? Appearances { get; set; }

    public int? Year { get; set; }

    public string? Universe { get; set; }
}
