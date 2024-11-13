


using System;
using System.Collections.Concurrent;

class Sanatci //sanatci sinifi tnaimlayip constructor ile destekliyoruz 
{
    public string AdSoyad { get; set; }
    public string Tur { get; set; }
    public int CikisYili { get; set; }
    public int AlbumSatisi { get; set; }

    public Sanatci (string adSoyad, string tur, int cikisYili, int albumSatisi)
    {
        AdSoyad = adSoyad;
        Tur = tur;
        CikisYili = cikisYili;
        AlbumSatisi = albumSatisi;
    }
}

class Program
{
    static void Main()
    {
        var sanatci = new List<Sanatci>()
        {
            new Sanatci ("Ajda Pekkan", "Pop", 1968, 20000000),
            new Sanatci ("Sezen Aksu", "Turk Halk Muzigi / Pop", 1971, 10000000),
            new Sanatci ("Funda Arar", "Pop", 1999, 3000000),
            new Sanatci ("Sertab Erener", "Pop", 1997, 5000000),
            new Sanatci ("Sila", "Pop", 2009, 3000000),
            new Sanatci ("Serdar Ortac", "Pop", 1994, 10000000),
            new Sanatci ("Tarkan", "Pop", 1992, 40000000),
            new Sanatci ("Hande Yener", "Pop", 1999, 7000000),
            new Sanatci ("Hadise", "Pop", 2005, 5000000),
            new Sanatci ("Gulben Ergen", "Pop / Turk halk muzigi", 1997, 10000000),
            new Sanatci ("Nesat Ertas", "Turk halk muzigi / turk sanat muzigi", 1960, 2000000),
        };

        Console.WriteLine("-----Adi S ile Baslayanlar--------");

        var adiS = sanatci.Where(x => x.AdSoyad.StartsWith('S'));  //S ile baslayan sanatci isimlerini startswith ile aliyoruz 

        foreach (var artist in adiS)  //foreach dongusu ile yazdiriyoruz
        {
            Console.WriteLine($"Adi: {artist.AdSoyad} Tur: {artist.Tur} Cikis Yili: {artist.CikisYili} Satis: {artist.AlbumSatisi}");
        }

        Console.WriteLine("-----------Albüm satışları 10 milyon'un üzerinde olan şarkıcılar----------");

        var onMilyon = sanatci.Where(x => x.AlbumSatisi > 10000000); //where kullanarak aliriz

        foreach (var artist in onMilyon)
        {
            Console.WriteLine($"Adi: {artist.AdSoyad} Tur: {artist.Tur} Cikis Yili: {artist.CikisYili} Satis: {artist.AlbumSatisi}");
        }

        Console.WriteLine("------------2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar.---------------");

        var popVe10Milyon = sanatci.Where(x => x.Tur.Contains("Pop") && x.CikisYili < 2000)
                                   .GroupBy(x => x.CikisYili); //cikis yili ile gruplandirip where ile buluyoruz 
                                   
        foreach (var grup in popVe10Milyon) //ilk once gruba girmemiz lazim foreach ile 
        {
            foreach (var artist in grup) //sonra gruptaki sanatcilara girmemiz lazim 
            {
                Console.WriteLine($"Adi: {artist.AdSoyad} Tur: {artist.Tur} Cikis Yili: {artist.CikisYili} Satis: {artist.AlbumSatisi}");
            }
        }

        Console.WriteLine("------------En çok albüm satan şarkıcı---------------");

        var enCokSatan = sanatci.OrderByDescending(x => x.AlbumSatisi).FirstOrDefault(); //descending ile coktan aza siraliyoruz 

        Console.WriteLine($"Adi: {enCokSatan.AdSoyad} Tur: {enCokSatan.Tur} Cikis Yili: {enCokSatan.CikisYili} Satis: {enCokSatan.AlbumSatisi}");

        Console.WriteLine("------------En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı---------------");

        var enYeniCikis = sanatci.OrderByDescending(x => x.CikisYili).FirstOrDefault(); //firstordefault ilk ornegi alir
        Console.WriteLine($"En yeni cikis yapan = Adi: {enYeniCikis.AdSoyad} Tur: {enYeniCikis.Tur} Cikis Yili: {enYeniCikis.CikisYili} Satis: {enYeniCikis.AlbumSatisi}");
        
        var enEskiCikis = sanatci.OrderBy(x => x.CikisYili).FirstOrDefault();
        Console.WriteLine($"En eski cikis yapan = Adi: {enEskiCikis.AdSoyad} Tur: {enEskiCikis.Tur} Cikis Yili: {enEskiCikis.CikisYili} Satis: {enEskiCikis.AlbumSatisi}");

    }
}

