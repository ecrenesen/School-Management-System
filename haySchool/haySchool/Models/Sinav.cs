using Microsoft.VisualBasic;
using NpgsqlTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;

namespace haySchool.Models
{
    public class Sinav
    {
        [Key]
        public int sinav_id { get; set; }
        public string sinav_ders_adi { get; set; }
        public int sinav_ders_id { get; set; }
        public int sinav_sinif_id { get; set; }
        public int sinav_ogretmen_id { get; set; }
        public string sinav_ogretmen_adi { get; set; }

        public DateTime sinav_date { get; set; }



    }
}