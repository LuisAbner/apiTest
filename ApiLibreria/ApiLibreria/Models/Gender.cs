using System;
using System.Collections.Generic;

namespace ApiLibreria.Models;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Gender1 { get; set; } = null!;

    public bool Estatus { get; set; }

    public virtual ICollection<BookGender> BookGenders { get; set; } = new List<BookGender>();
}
