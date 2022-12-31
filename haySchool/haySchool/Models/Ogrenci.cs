using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;

namespace haySchool.Models
{
    public class Ogrenci
    {
        [Key]
        public int ogrenci_id { get; set; }
        public string ogrenci_tcno { get; set; }
        public string ogrenci_adi { get; set; }
        public string ogrenci_soyadi { get; set; }
        public int ogrenci_sinif_id{ get; set; }
        public string ogrenci_sinif_adi{ get; set; }
        public IEnumerable<SelectListItem> siniflar { get; set; }
        public int ogrenci_veli_id { get; set; }
        public string ogrenci_veli_adi { get; set; }
        public DateTime ogrenci_kayit_tarihi{ get; set; }

        public int ogrenci_devamsizlik { get; set; }
    }
}
