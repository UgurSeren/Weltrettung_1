namespace Weltrettung_1.Models
{
    public class Bedroh
    {
        public int bedroh_id { get; set; }
        public string? bedroh_name { get; set; }

        public bool existenz { set; get; }

        public int? agressor_id { set; get; }
        public int? held_id { set; get; } 

    }
}
