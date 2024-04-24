using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public List<Interest> Interests { get; set; } = new List<Interest>();
    }
}
