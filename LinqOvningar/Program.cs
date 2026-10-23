namespace LinqOvningar
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string Namn { get; set; } = "";
            public int Alder { get; set; }
            public string Klass { get; set; } = "";
            public int Poang { get; set; }
        }

        public static void Print(string description, List<Student> students)
        {
            Console.WriteLine($"{description}:");
            if (students.Count > 0)
            {
                foreach (Student s in students)
                {
                    Console.WriteLine($"- {s.Namn}");
                }
            }
            else
            {
                Console.WriteLine($"Inga studenter");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            // Exempeldata
            List<Student> studenter = new List<Student>
                {
                    new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
                    new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
                    new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
                    new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
                    new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
                    new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
                    new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
                    new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
                };
            Console.WriteLine("LI NQ-ÖVNINGAR MED STUDENTER\n");

            // Where
            // - Hämta alla studenter som är äldre än 20
            var studenterAlderOver20 = studenter.Where(s => s.Alder > 20).ToList();
            Print("Studenter äldre än 20", studenterAlderOver20);

            // - Hämta alla studenter som har mer än 80 poäng.
            var studenterPoangOver80 = studenter.Where(s => s.Poang > 80);
            Print("Studenter med mer än 80 poäng", studenterAlderOver20);
        }
    }
}
