using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace beekeepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}