using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class TemplateListDTO
    {
        public int TemplateId { get; set; }

        public string TemplateTitle { get; set; }

        public bool PublishStatus { get; set; }

        public bool VideoStatus { get; set; }
    }
}
