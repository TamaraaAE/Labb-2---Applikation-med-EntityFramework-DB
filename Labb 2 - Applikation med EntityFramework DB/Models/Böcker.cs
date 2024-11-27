using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string? Titel { get; set; }

    public string? Språk { get; set; }

    public int Pris { get; set; }

    public DateOnly? Utgivningsdatum { get; set; }

    public int? FörfattarId { get; set; }

    public int? FörlagId { get; set; }

    public virtual Författare? Författar { get; set; }

    public virtual Förlag? Förlag { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
