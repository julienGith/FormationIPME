using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWpf.ZooModels;

namespace ZooWpf.ZooRepo
{
    public interface IZooFakeRepo
    {
        List<Animal> GetAllAnimals();
    }
}
