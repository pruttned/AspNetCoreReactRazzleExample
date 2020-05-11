
using System.Collections.Generic;
using System.Linq;
using AspNetCoreRazzleExample.Models;

namespace AspNetCoreRazzleExample.Services
{
    public interface IHeroDb
    {
        Hero[] GetAll();
        Hero Get(int id);
    }

    public class HeroDb : IHeroDb
    {
        private readonly Hero[] _items = new[]
        {
            new Hero{
                Id= 1,
                Name= "Luke Skywalker",
                Height= 172,
                Mass= 77,
                BirthYear= "19BBY",
            },
            new Hero{
                Id= 2,
                Name= "C-3PO",
                Height= 167,
                Mass= 75,
                BirthYear= "112BBY",
            },
             new Hero{
                Id= 3,
                Name= "R2-D2",
                Height= 96,
                Mass= 32,
                BirthYear= "33BBY",
            },
            new Hero{
                Id= 4,
                Name= "Darth Vader",
                Height= 202,
                Mass= 136,
                BirthYear= "41.9BBY",
            }
        };

        public Hero[] GetAll() => _items;
        public Hero Get(int id) => _items.SingleOrDefault(h => h.Id == id);
    }
}