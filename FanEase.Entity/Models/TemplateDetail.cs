
using FanEase.HelperClasses.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class TemplateDetail
    {
        public int TemplateDetailsId { get; set; }

        [Required(ErrorMessage ="Enter Title for Template")]
        public string TemplateTitle { get; set; }

        [Required(ErrorMessage = "Select Type of Template")]
        public string TemplateType { get; set; }

        public int? Section1 { get; set; }

        public int? Section2 { get; set; }

        public int? Section3 { get; set; }

        public int? Section4 { get; set; }

        public int? Section5 { get; set; }

        public int? Section6 { get; set; }

        public int? Section7 { get; set; }

        public int? Section8 { get; set; }

        public string UserId { get; set; }

    }
}
