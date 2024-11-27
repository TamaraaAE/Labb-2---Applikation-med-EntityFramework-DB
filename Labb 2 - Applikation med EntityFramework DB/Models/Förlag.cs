using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Förlag
{
    public int FörlagId { get; set; }

    public string Förlagsnamn { get; set; } = null!;

    public string? Land { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
