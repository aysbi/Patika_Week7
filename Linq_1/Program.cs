
Random random = new Random();  //bir random aciyoruz
List<int> numbers = new List<int>(); //numbers adinda liste hazirliyoruz

for (int i = 0; i < 10; i++) //for dongusu ile rastgele 10 sayi listenin icine siraliyoruz
{
    numbers.Add(random.Next(-100, 100));
}

foreach (int num in numbers)
{
    Console.WriteLine(num);
}

Console.WriteLine("-------------------Cift Sayilar-------------------");

var EvenNums = numbers.Where(x => x % 2 == 0); //ciftlik durumuna bakilir

foreach  (var num in EvenNums)
{
    Console.WriteLine(num);
}

Console.WriteLine("---------------Tek Sayilar-----------------");

var OddNums =  numbers.Where(x => x % 2  != 0 ); //teklik durumuna bakilir

foreach (var num in OddNums)
{
    Console.WriteLine(num);
}

Console.WriteLine("-------------------Negatif Sayılar----------------");

var NegativeNums = numbers.Where(x => x < 0); //negatiflige bakilir 

foreach (var num in NegativeNums)
{
    Console.WriteLine(num);
}

Console.WriteLine("----------------Pozitif Sayilar------------");

var PositiveNums = numbers.Where(x => x >= 0); // pozitiflige bakilir

foreach (var num in PositiveNums)
{
    Console.WriteLine(num);
}

Console.WriteLine("------------15'ten büyük ve 22'den küçük sayılar-----------");

var BetweenNums = numbers.Where(x => x < 25 && x > 15).ToList(); //iki kosulunda saglandigi sayilar gozukur

if (BetweenNums.Count == 0) //eger listede bir sayi yoksa bu calisir ve sayi olmadigini belirtir
    Console.WriteLine("Bu sayilar icinde yok");

foreach (var num in BetweenNums)
{
    Console.WriteLine(num);
}

Console.WriteLine("--------------Karesi---------------");

var SquaredNums = numbers.Select(x => x * x ).ToList(); //select ile yapilir karesini aliriz

foreach (var num in SquaredNums)
{
    Console.WriteLine(num);
}
