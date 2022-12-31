using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Veli
    {

        [Key]
        public int veli_id { get; set; }
        public string veli_adi { get; set; }
        public string veli_soyadi { get; set; }
        public string veli_telno { get; set; }
        public string veli_adres { get; set; }
        //public int veli_odeme_id { get; set; }
     

    }
}
