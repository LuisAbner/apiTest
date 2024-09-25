using System;
using System.Collections.Generic;

namespace ApiLibreria.Models;

public partial class Book
{
    public int IdBook { get; set; }

    public string BookName { get; set; } = null!;

    public int Page { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BookGender> BookGenders { get; set; } = new List<BookGender>();
}
