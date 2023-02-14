using System.ComponentModel.DataAnnotations;

namespace EFCoreTutorial.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
       
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Song> AllSongs { get; set; } = null!;
    }
}
