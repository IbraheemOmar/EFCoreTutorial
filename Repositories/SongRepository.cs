using EFCoreTutorial.Context;
using EFCoreTutorial.Models;
using EFCoreTutorial.Repositories.Interfaces;

namespace EFCoreTutorial.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(MusicContext dbContext):base(dbContext)
        {
          
        }
    }
}
