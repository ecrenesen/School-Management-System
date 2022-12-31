namespace haySchool.Models
{
    public class Etut
    {
        public int etut_id { get; set; }

        public string etut_ogrenci_adi { get; set; }
        public int etut_ogrenci_id { get; set; }

      

        public string etut_ders_adi { get; set; }
        public int etut_ders_id { get; set; }
        public int etut_sinav_id { get; set; }

    }
}