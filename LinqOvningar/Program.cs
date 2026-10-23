using static LinqOvningar.Program;

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


        static void PrintList<T>(string description, IEnumerable<T> items, Func<T, string> format)
        {
            Console.WriteLine($"{description}:");
            foreach (T item in items)
            {
                Console.WriteLine($"- {format(item)}");
            }
            Console.WriteLine();
        }
        static string StudentToString(Student s) => $"Namn: {s.Namn}, Ålder: {s.Alder}, Klass: {s.Klass}, Poäng: {s.Poang}";
        static void Title(string text) => Console.WriteLine($"=== {text} ===\n");

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
            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");

            // Where
            Title("Where");

            // - Hämta alla studenter som är äldre än 20
            var studenterAlderOver20 = studenter.Where(s => s.Alder > 20);
            PrintList("Äldre än 20", studenterAlderOver20, StudentToString);

            // - Hämta alla studenter som har mer än 80 poäng.
            var studenterPoangOver80 = studenter.Where(s => s.Poang > 80);
            PrintList("Mer än 80 poäng", studenterPoangOver80, StudentToString);


            // Select
            Title("Select");

            // - Visa bara namnen på alla studenter
            var studenterNamn = studenter.Select(s => s.Namn);
            PrintList("Namn", studenterNamn, name => name);

            // - Visa namn och poäng i en ny anonym typ
            var studenterNamnOchPoang = studenter.Select(s => new { s.Namn, s.Poang });
            PrintList("Namn och poäng", studenterNamnOchPoang, s => $"{s.Namn} {s.Poang}p");

            // OrderBy
            Title("OrderBy");

            // - Sortera studenter efter ålder
            var studenterEfterAlder = studenter.OrderBy(s => s.Alder);
            PrintList("Sorterade efter ålder", studenterEfterAlder, StudentToString);

            // - Sortera studenter efter poäng, högst först
            var studenterEfterPoang = studenter.OrderByDescending(s => s.Poang);
            PrintList("Sorterade efter poäng", studenterEfterPoang, StudentToString);

            // Count
            Title("Count");

            // - Räkna hur många studenter som finns
            var antalStudenter = studenter.Count();
            Console.WriteLine($"Antal studenter: {antalStudenter}");

            // - Räkna hur många som går i klass A
            var antalStudenterKlassA = studenter.Where(s => s.Klass == "A").Count();
            Console.WriteLine($"Antal studenter: {antalStudenterKlassA}\n");

            // Take
            Title("Take");

            // - Ta ut de tre första studenterna
            var treForstaStudenter = studenter.Take(3);
            PrintList("Tre första studenterna", treForstaStudenter, StudentToString);

            // - Ta ut de två bästa poängen efter sortering
            var tvaBastaPoangen = studenter.OrderByDescending(s => s.Poang).Take(2);
            PrintList("De två bästa poängen", tvaBastaPoangen, s => s.Poang.ToString());
        }
    }
}
