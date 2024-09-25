using System;
using System.Collections.Generic;

namespace ApiLibreria.Models;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string Author1 { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
