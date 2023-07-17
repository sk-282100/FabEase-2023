using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class Templates
    {
        [Key]
        public int TemplateId { get; set; }
        
        public int TemplateDetailsId { get; set; }
        
        public string UserId { get; set; }
    }
}
