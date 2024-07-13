using Microsoft.EntityFrameworkCore;
using New_Revision.Models;
using System.Globalization;

namespace New_Revision.Serivices
{
    public class HeroService : IHeroService
    {
        private readonly HeroesDbContext _dbHeroes;
        public HeroService(HeroesDbContext heroesDbContext)
        {
            _dbHeroes = heroesDbContext;
        }
        public async Task<List<Hero>> GetHeroesList()
        {
            return await _dbHeroes.Heroes.ToListAsync();
        }

        public async Task SaveHero(Hero hero)
        {
            _dbHeroes.Heroes.Add(hero);
            await _dbHeroes.SaveChangesAsync();
        }

        public async Task<Hero> GetHeroById(int id)
        {
            return await _dbHeroes.Heroes.Where(hero => hero.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateHero(Hero hero)
        {
           _dbHeroes.Heroes.Update(hero);
           await _dbHeroes.SaveChangesAsync();
        }

    }
}
