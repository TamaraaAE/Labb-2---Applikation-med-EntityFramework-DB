using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Kunder
{
    public int KundId { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public string Epost { get; set; } = null!;

    public string? Telefon { get; set; }

    public string? Adress { get; set; }

    public string? Postnummer { get; set; }

    public string? Stad { get; set; }
}
