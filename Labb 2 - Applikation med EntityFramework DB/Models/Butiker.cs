using System;
using System.Collections.Generic;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Butiker
{
    public int ButikId { get; set; }

    public string ButiksNamn { get; set; } = null!;

    public string GatuAdress { get; set; } = null!;

    public string Postnummer { get; set; } = null!;

    public string Stad { get; set; } = null!;

    public string Land { get; set; } = null!;

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
