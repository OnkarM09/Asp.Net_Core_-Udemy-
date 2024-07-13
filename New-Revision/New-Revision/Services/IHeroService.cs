using New_Revision.Models;

namespace New_Revision.Serivices
{
    public interface IHeroService
    {
        Task<List<Hero>> GetHeroesList();

        Task SaveHero(Hero hero);

        Task<Hero> GetHeroById(int id);

        Task UpdateHero(Hero hero);

    }
}
