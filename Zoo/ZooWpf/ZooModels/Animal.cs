using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWpf.ZooModels
{
    public abstract class Animal
    {
        public Animal(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
        }
        private string _imgLink;

        public string ImgLink
        {
            get { return _imgLink; }
            set { _imgLink = value; }
        }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
