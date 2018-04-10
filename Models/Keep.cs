using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace beekeepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string ArticleUrl { get; set; }
        public int Public { get; set; }
        public int KeepCount { get; set; }
        public int ShareCount { get; set; }
        public int ViewCount { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}