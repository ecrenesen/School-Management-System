using System;

namespace haySchool.Models
{
    public class Taksit
    {
        public int taksit_id { get; set; }
        public int taksit_odeme_id { get; set; }
        public DateTime taksit_tarih { get; set; }
        public double taksit_tutar { get; set; }
    }
}
