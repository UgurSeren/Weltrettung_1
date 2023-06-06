namespace Weltrettung_1.Models
{
    public static class Speichern
    {
        public static List<Detail> list = new List<Detail>();
        public static IEnumerable<Detail> numm => list;

        public static void Add(Detail h)
        {
            Console.WriteLine(h);
            list.Add(h);
        }
    }
}
