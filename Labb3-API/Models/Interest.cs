using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [MaxLength(50)]
        [Required]
        public string InterestName { get; set; }
        [MaxLength(130)]
        public string InterestDescription { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
