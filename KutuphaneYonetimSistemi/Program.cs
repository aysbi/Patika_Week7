class Authors //yazarlar icin class olusturuyoruz
{
    public int AuthorId { get; set; }
    public string Name { get; set; }

    public Authors (int authorId, string name) 
    {
        AuthorId = authorId;
        Name = name;
    }
}

class Book //kitaplar icin class olusturuyoruz
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }

    public Book(int bookId, string title, int authorId)
    {
        BookId = bookId;
        Title = title;
        AuthorId = authorId;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Authors> yazarlar = new List<Authors>() //yazarlar icin bir liste olusturup degerleri giriyoruz
        {
            new Authors(1, "Orhan Pamuk"),
            new Authors(2, "Elif Safak"),
            new Authors(3, "Ahmet Umit")
        };

        List<Book> kitaplar = new List<Book>() //kitaplar icin bir liste olusturup degerleri giriyoruz
        {
            new Book (1, "Kar", 1),
            new Book (2, "Istanbul", 1),
            new Book (3, "10 Minutes 38 Seconds in This Strange World", 2),
            new Book (4, "Beyoglu Rapsodisi", 3)
        };

        var yazarlarVeKitaplari = from book in kitaplar //join yapisini kullanip birlestiriyoruz
                                  join author in yazarlar on book.AuthorId equals author.AuthorId
                                  select new {book.Title, author.Name};

        foreach (var results in yazarlarVeKitaplari) //ve bu sonuclari yazdiriyoruz
        {
            Console.WriteLine($"Kitabin adi: {results.Title}, Yazari: {results.Name}");
        }

    }
}
