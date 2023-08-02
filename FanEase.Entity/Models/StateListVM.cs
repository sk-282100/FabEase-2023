using System.ComponentModel.DataAnnotations;

namespace FanEase.Entity.Models
{
    public class StateListVM
    {
        public int StateId { get; set; }
      
        public string StateName { get; set; }

        public string CountryName { get; set; }
    }
}
