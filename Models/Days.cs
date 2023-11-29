using System.ComponentModel.DataAnnotations.Schema;

namespace StundenplanApp.Models
{
    public class Days
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }
        public Users User { get; set; }
        public Tage Tag { get; set; }
        public int Stunde1 { get; set; }
        public int Stunde2 { get; set; }
        public int Stunde3 { get; set; }
        public int Stunde4 { get; set; }
        public int Stunde5 { get; set; }
        public int Stunde6 { get; set; }
        public int Stunde7 { get; set; }
        public int Stunde8 { get; set; }
    }
    public enum Tage
    {
        Montag,
        Dienstag,
        Mittwoch,
        Donnerstag,
        Freitag
    }
}
