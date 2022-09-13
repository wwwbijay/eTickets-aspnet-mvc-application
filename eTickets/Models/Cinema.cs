using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Logo is Required!")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "Description is Required!")]
        public string Description { get; set; }

        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
