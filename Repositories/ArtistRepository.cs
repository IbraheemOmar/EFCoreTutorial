using EFCoreTutorial.Context;
using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories.Interfaces;

namespace EFCoreTutorial.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicContext dbContext) : base(dbContext)
        {
            
        }
    }
}
