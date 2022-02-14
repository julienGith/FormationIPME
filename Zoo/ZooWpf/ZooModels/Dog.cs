using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWpf.ZooModels
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
            this.ImgLink = "https://cdn-icons-png.flaticon.com/512/194/194279.png";
        }
    }
}
