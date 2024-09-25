using System;
using System.Collections.Generic;

namespace ApiLibreria.Models;

public partial class BookGender
{
    public int IdBookGender { get; set; }

    public int? BookId { get; set; }

    public int? GenderId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Gender? Gender { get; set; }
}
