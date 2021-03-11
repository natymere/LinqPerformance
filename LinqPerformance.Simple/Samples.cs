using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace LinqPerformance.Simple
{
    public class Samples
    {
        private readonly Faker<Drink> _faker = new();
        private readonly List<Drink> _drinks;

        public Samples()
        {
            _drinks = _faker
                .RuleFor(drink => drink.Name, faker => faker.Name.FullName())
                .RuleFor(drink => drink.IsAlcoholic, faker => faker.Random.Bool())
                .Generate(6000);
        }

        public int AlcoholicDrinksCountLinqWhere()
        {
            return _drinks.Where(x => x.IsAlcoholic).Count();
        }

        public int AlcoholicDrinksCountLinqCount()
        {
            return _drinks.Count(x => x.IsAlcoholic);
        }

        public int AlcoholicDrinksCountForEach()
        {
            var count = 0;
            foreach (var drink in _drinks)
            {
                if (drink.IsAlcoholic)
                {
                    count++;
                }
            }

            return count;
        }

        public int AlcoholicDrinksCountForLoop()
        {
            var count = 0;
            for (int i = 0; i < _drinks.Count(); i++)
            {
                if (_drinks[i].IsAlcoholic)
                {
                    count++;
                }
            }

            return count;
        }

        public List<string> NonAlcoholicDrinkNamesForLoop()
        {
            var names = new List<string>();
            for (int i = 0; i < _drinks.Count(); i++)
            {
                var drink = _drinks[i];
                if (!drink.IsAlcoholic)
                {
                    names.Add(drink.Name);
                }
            }

            return names;
        }

        public List<string> NonAlcoholicDrinkNamesLinq()
        {
            return _drinks.Where(x => !x.IsAlcoholic).Select(x => x.Name).ToList();
        }
    }
}