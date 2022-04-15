using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
    }
}
