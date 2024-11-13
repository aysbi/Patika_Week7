class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }

    public Student (int studentId, string studentName, int classId)
    {
        StudentId = studentId;
        StudentName = studentName;
        ClassId = classId;
    }
}
class Classes
{
    public int ClassId { get; set; }
    public string Name { get; set; }

    public Classes (int classId, string name)
    {
        ClassId = classId;
        Name = name;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Student> ogrenciler = new List<Student>()
        {
            new Student (1, "Ali", 1),
            new Student (2, "Ayse", 2),
            new Student (3, "Mehmet", 1),
            new Student (4, "Fatma", 3),
            new Student (5, "Ahmet", 2),
        };

        List<Classes> siniflar = new List<Classes>()
        {
            new Classes (1, "Matematik"),
            new Classes (2, "Turkce"),
            new Classes (3, "Kimya")
        };

        var ogrencilerVeSiniflar = siniflar.GroupJoin(
                                   ogrenciler,
                                   x => x.ClassId,
                                   y => y.ClassId,
                                   (sinif, ogrenciGrubu) => new
                                   {
                                       sinifAdi = sinif.Name,
                                       Ogrenciler = ogrenciGrubu
                                   }
                                   );

        foreach (var group in  ogrencilerVeSiniflar)
        {
            Console.WriteLine("Ders: " + group.sinifAdi);

            foreach(var ogrenci in group.Ogrenciler)
            {
                Console.WriteLine($"Ogrenci: {ogrenci.StudentName}");
            }
        }

    }
}