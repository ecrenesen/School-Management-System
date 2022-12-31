using System;

namespace haySchool.Models
{
    public class Devamsizlik
    {
        public int devamsizlik_id { get; set; }
        public int devamsizlik_ogrenci_id { get; set; }
        public int devamsizlik_miktar { get; set; }
        public DateTime devamsizlik_tarih { get; set; }
        public string devamsizlik_ogrenci_adi { get; set; }
    }
}
