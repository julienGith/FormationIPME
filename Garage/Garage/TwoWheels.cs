﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class TwoWheels : Vehicle
    {
        public TwoWheels(int id, string name, string state, string model, string brand, string kilometrage) : base(id, name, state, model, brand, kilometrage)
        {
        }
    }
}
