using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Ogretmen
    {
        [Key]
        public int ogretmen_id { get; set; }
        public int ogretmen_ders_id { get; set; }
        public string ogretmen_ders_adi { get; set; }
        public string ogretmen_adi { get; set; }
        public string ogretmen_soyadi { get; set; }
        public string ogretmen_telno { get; set; }
       
    }
}