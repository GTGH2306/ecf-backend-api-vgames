using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecf.Vgames.Models
{
    [Table("gizmondo")]
    public class Gizmondo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("game")]
        [Required]
        public required string Game { get; set; }

        [Column("year")]
        [Required]
        public required int Year { get; set; }

        [Column("dev")]
        [Required]
        public required string Dev { get; set; }

        [Column("publisher_id")]
        [ForeignKey("Publisher")]
        [Required]
        public required int PublisherId { get; set; }
        [JsonIgnore]
        public Publisher? Publisher { get; set; }
    }
}
