using System.Collections.Generic;

namespace beekeepr.Models
{
    public class AllKeepsResults
    {
        public int Id { get; set; }
        public Dictionary<int, List<Keep>> Results { get; set; }
    }
}