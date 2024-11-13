
class Diziler
{
    public string Adi { get; set; }
    public int YapimYili {  get; set; }
    public string Tur {  get; set; }
    public int YayinlanmaYili {  get; set; }
    public string Yonetmen {  get; set; }
    public string Platform { get; set; }

    public Diziler (string adi, int yapimYili, string tur, int yayinlanmaYili, string yonetmen, string platform)
    {
        Adi = adi;
        YapimYili = yapimYili;
        Tur = tur;
        YayinlanmaYili = yayinlanmaYili;
        Yonetmen = yonetmen;
        Platform = platform;
    }
    public static Diziler DiziEkle()
    {
        Console.Write("Dizi adı: ");
        string adi = Console.ReadLine();

        Console.Write("Yapım yılı: ");
        int yapimYili = int.Parse(Console.ReadLine());

        Console.Write("Tür: ");
        string tur = Console.ReadLine();

        Console.Write("Yayınlanma yılı: ");
        int yayinlanmaYili = int.Parse(Console.ReadLine());

        Console.Write("Yönetmen: ");
        string yonetmen = Console.ReadLine();

        Console.Write("Platform: ");
        string platform = Console.ReadLine();

        return new Diziler(adi, yapimYili, tur, yayinlanmaYili, yonetmen, platform);
    }
}
class KomediDizileri 
{
    public string Adi { get; set; }
    public string Tur { get; set; }
    public string Yonetmen { get; set; }

    public KomediDizileri(string ad, string tur, string yonetmen)
    {
        Adi = ad; 
        Tur = tur;
        Yonetmen = yonetmen;
    }
}
class Program
{
    static void Main()
    {
        List<Diziler> diziListesi = new List<Diziler>();

        bool dongu = true;

        do
        {
            Diziler yeniDizi = Diziler.DiziEkle();
            diziListesi.Add(yeniDizi);

            Console.WriteLine("Yeni dizi eklemek ister misiniz? Evet/Hayir");
            string cevap = Console.ReadLine().ToLower();

            if (cevap != "evet")
                dongu = false;

        } while (dongu);
        
        List<KomediDizileri> komediListesi = new List<KomediDizileri>();
        foreach (var dizi in diziListesi)
        {
            if (dizi.Tur == "komedi" || dizi.Tur == "Komedi")
            {
                var komediDizi = new KomediDizileri(dizi.Adi, dizi.Tur, dizi.Yonetmen);
                komediListesi.Add(komediDizi);
            }
        }

        Console.WriteLine("-------Listedeki Komedi Dizileri----------\r\n");

        var siraliKomediDizisi = komediListesi.OrderBy(x => x.Adi).ThenBy(x => x.Yonetmen);

        foreach (var dizi in komediListesi)
        {
            Console.WriteLine($"Dizi Adi: {dizi.Adi}, Dizi turu: {dizi.Tur}, Dizi Yonetmeni: {dizi.Yonetmen}");
        }
    }
}



