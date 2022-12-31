using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class Ders
    {
        [Key]
        public int ders_id { get; set; }

        public string ders_adi { get; set; }


    }
}