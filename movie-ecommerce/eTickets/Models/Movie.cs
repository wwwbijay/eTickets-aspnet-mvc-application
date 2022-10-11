using eTickets.Data.Base;
using eTickets.Data.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Image Url is Required!")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Start Date is Required!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is Required!")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Movie Category is Required!")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
