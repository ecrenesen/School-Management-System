using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Sinif
    {
        [Key]
        public int sinif_id { get; set; }
        public int sinif_sube { get; set; }
        public int sinif_ogretmen_id { get; set; }
        public string sinif_ogretmen_adi { get; set; }
        public int sinif_mevcut { get; set; }



    }
}