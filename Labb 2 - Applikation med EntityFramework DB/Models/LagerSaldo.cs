using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class LagerSaldo
{
    public int Antal { get; set; }

    public int ButikId { get; set; }

    public string Isbn { get; set; } = null!;

    public virtual Butiker Butik { get; set; } = null!;

    public virtual Böcker IsbnNavigation { get; set; } = null!;
}
