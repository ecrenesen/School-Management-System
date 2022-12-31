using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Sonuc
    {
        [Key]
        public int sonuc_id { get; set; }
        public int sonuc_sinav_id { get; set; }
        public string sonuc_sinav_adi { get; set; }
        public int sonuc_ogrenci_id { get; set; }
        public string sonuc_ogrenci_adi { get; set; }
        public int sonuc_puan { get; set; }
        public  int  sonuc_ders_id { get; set; }


    }
}

