using EventRegistration.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistration.Models
{
    public class Applicant
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PerformanceType { get; set; }
        public string ParticipantName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string GroupName { get; set; }
        public string NoOfMembers { get; set; }
        public string AgeGroupRange { get; set; }
        public string GroupType { get; set; }
        public string Details { get; set; }
        public long OrderId { get; set; }
        public string TransactionId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

    }
}
