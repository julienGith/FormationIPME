using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBinding.Models
{
    public class AdminModel: UserModel

    {
        public bool IsAdmin { get; set; } = true;
    }
}
