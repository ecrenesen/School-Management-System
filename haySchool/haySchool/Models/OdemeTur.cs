using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace haySchool.Models
{
    public class OdemeTur
    {

        [Key]
        public int odemetur_id { get; set; }
        public string odemetur_adi { get; set; }

    }
}
