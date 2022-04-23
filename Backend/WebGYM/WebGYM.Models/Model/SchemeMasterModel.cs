using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace WebGYM.Models.Model
{
    public class SchemeMasterModel
    {
        [Required(ErrorMessage = "SchemeName is Required")]
        public string SchemeName { get; set; }

        public bool Status { get; set; }
    }
    public class SchemeMasterEditViewModel
    {
        [Required(ErrorMessage = "SchemeID is Required")]
        public int SchemeID { get; set; }

        [Required(ErrorMessage = "SchemeName is Required")]
        public string SchemeName { get; set; }

        public bool Status { get; set; }
    }


}
