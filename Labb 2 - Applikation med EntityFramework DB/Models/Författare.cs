using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Författare
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Födelseår { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
