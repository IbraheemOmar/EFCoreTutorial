using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; } = null!;
        
    }
}
