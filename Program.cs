using LinqAndLambda.Entities;

namespace LinqAndLambda
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (var obj in collection)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
        }
        
        public static void Main(string[] args)
        {
            var category1 = new Category { Id = 1, Name = "Tools", Tier = 2 };
            var category2 = new Category { Id = 2, Name = "Computer", Tier = 1 };
            var category3 = new Category { Id = 3, Name = "Eletronics", Tier = 1 };
            
            var products = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Computer", Price = 1100.0, Category = category2 },
                new Product(){ Id = 2, Name = "Hammer", Price = 90.0, Category = category1 },
                new Product(){ Id = 3, Name = "TV", Price = 1700.0, Category = category3 },
                new Product(){ Id = 4, Name = "Notebook", Price = 1300.0, Category = category2 },
                new Product(){ Id = 5, Name = "Saw", Price = 80.0, Category = category1 },
                new Product(){ Id = 6, Name = "Tablet", Price = 700.0, Category = category2 },
                new Product(){ Id = 7, Name = "Camera", Price = 700.0, Category = category3 },
                new Product(){ Id = 8, Name = "Printer", Price = 350.0, Category = category3 },
                new Product(){ Id = 9, Name = "MacBook", Price = 1800.0, Category = category2 },
                new Product(){ Id = 10, Name = "Sound Bar", Price = 700.0, Category = category3 },
                new Product(){ Id = 11, Name = "Level", Price = 70.0, Category = category1 }
            };
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);
            Print("TIER 1",r1);
            
            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("Tools:",r2);
            
            var r3 = products.Where(p => p.Name[0] == 'C')
                .Select(p => new {p.Name, p.Price, CategoryName = p.Category.Name});
            Print("Letter C", r3);
            
            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price)
                .ThenBy(p => p.Name);
            Print("Tier 1:", r4);
            
            var r5 = r4.Skip(2).Take(4);
            Print("r5", r5);
            
            var r6 = products.First();
            Console.WriteLine($"First {r6}");
            
            var r7 = products.Where(p =>  p.Price == 3000.0).FirstOrDefault();
            Console.WriteLine("First or Default:" + r7);
            
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or Default:" + r8);
            
            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine($"Single or default null {r9}");



        }
    }
}
