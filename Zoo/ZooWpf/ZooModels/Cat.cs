using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWpf.ZooModels
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
            this.ImgLink = "http://cdn.onlinewebfonts.com/svg/img_547265.png";
        }
    }
}
