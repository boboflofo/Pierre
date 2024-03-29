using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
  public class Flavor
    {
        public int FlavorId { get; set; }
        [Required(ErrorMessage = "The flavor's name can't be empty!")]
        public string Name { get; set; }

        public List<TreatFlavor> JoinEntities { get;}
        public ApplicationUser User { get; set; }
    }
}