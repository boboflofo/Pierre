using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
  public class Treat
    {
        public int TreatId { get; set; }
        [Required(ErrorMessage = "The treat's name can't be empty!")]
        public string Name { get; set; }
        public List<TreatFlavor> JoinEntities { get;}

    }
}