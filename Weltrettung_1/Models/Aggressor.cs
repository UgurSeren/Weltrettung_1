namespace Weltrettung_1.Models
{
    public class Aggressor
    {
        public int id { get; set; }
        public string? vorname { get; set; }
        public string? nachname { get; set; }
        public string? spezialitaet { set; get; }

        public int held_id { get; set; }   
    }
}
