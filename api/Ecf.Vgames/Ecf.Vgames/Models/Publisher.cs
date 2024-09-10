using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecf.Vgames.Models
{
    [Table("publisher")]
    public class Publisher
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        [Required]
        public required string Name { get; set; }

        public ICollection<Gizmondo>? Gizmondos { get; set; }
    }
}
