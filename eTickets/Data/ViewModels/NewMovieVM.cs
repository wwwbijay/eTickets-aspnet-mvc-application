using eTickets.Data.Base;
using eTickets.Data.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is Required!")]
        public string Description { get; set; }
        [Display(Name = "Price in Rs.")]
        [Required(ErrorMessage = "Price is Required!")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster")]
        [Required(ErrorMessage = "Movie Poster URL is Required!")]
        public string ImageUrl { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required!")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required!")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Movie Genre")]
        [Required(ErrorMessage = "Movie Category is Required!")]
        public MovieCategory MovieCategory { get; set; }
        //Relationships
        [Display(Name = "Select Actors")]
        [Required(ErrorMessage = "Movie Actor(s) is Required!")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Movie Cinema is Required!")]
        public int CinemaId { get; set; }
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Movie Producer is Required!")]
        public int ProducerId { get; set; }
    }
}
