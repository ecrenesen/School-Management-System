using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Odeme
    {

        [Key]
        public int odeme_id { get; set; }
        public int odeme_odemetur_id { get; set; }
        public string odeme_odemetur_adi { get; set; }
        public double odeme_toplam { get; set; }
        public double odeme_odenen { get; set; }
        public double odeme_kalan { get; set; }
        public double odeme_indirim { get; set; }
        public int odeme_veli_id { get; set; }
        public string odeme_veli_adi { get; set; }


      
    }
}
