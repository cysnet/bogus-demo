using Bogus;
using Newtonsoft.Json;

namespace fakertest
{
    internal class Program
    {
        public static List<string> Schools = new List<string> { "北大", "清华", "南开", "哈佛" };
        static void Main(string[] args)
        {
            var generater = new Faker<BogusType>("ja")
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Age, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Birthday, f => f.Date.Future())
                .RuleFor(x => x.Amount, f => f.Random.Decimal())
                .RuleFor(x => x.Heigt, f => f.Random.Double())
                .RuleFor(x => x.Gender, f => f.PickRandom<Gender>())
                .RuleFor(x => x.School, f => f.PickRandom(Schools));

            var data = generater.Generate();
            SerializeObject(data);

            var datas = generater.Generate(2);
            SerializeObject(datas);

            var g = generater.GenerateForever();
            SerializeObject(g.Take(1).ToList());
            SerializeObject(g.Take(1).ToList());
            SerializeObject(g.Take(1).ToList());
        }

        static void SerializeObject(object obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

    }

}