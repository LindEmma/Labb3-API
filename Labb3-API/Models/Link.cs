using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string Url { get; set; }

        [ForeignKey("Interest")]
        public int InterestId { get; set; }
    }
}
