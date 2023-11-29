using System.ComponentModel.DataAnnotations.Schema;
namespace StundenplanApp.Models
{
    public class Subjects
    {
        public int ID { get; set; }
        public Subject Name { get; set; }
        public string Raum { get; set; }
        public string Lehrkraft { get; set; }
    }

    public enum Subject
    {
        Deutsch,
        Englisch,
        Mathe,
        Erdkunde,
        Sport,
        Physik,
        Chemie,
        Biologie,
        Geschichte,
        Französisch,
        Spanisch,
        Latein,
        Kursunterricht,
        Verfügung,
        Politik,
        Wirtschaft,
        NTW,
        GSW
    }
}
