using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWpf.ZooModels;

namespace ZooWpf.ZooRepo
{
    public class ZooFakeRepo : IZooFakeRepo
    {
        public List<Animal> GetAllAnimals()
        {
            var animals = new List<Animal>() { 
                new Dog("Akita Américain"),
                new Dog("Basset Bleu de Gascogne"),
                new Dog("Berger Catalan"),
                new Dog("Labradoodle"),
                new Cat("Abyssin"),
                new Cat("Havana Brown"),
                new Cat("Scottish Fold"),
                new Cat("York Chocolat"),
            };
            return animals;
        }
    }
}
