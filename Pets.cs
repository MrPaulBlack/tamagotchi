using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    abstract class Pets
    {
        public string name;
        public string owner;
        public string kind;

        //query name
        public string get_name()
        {
            return name;
        }

        //query kind
        public string get_kind()
        {
            return kind;
        }

        //query owner
        public string get_owner()
        {
            return owner;
        }
    }
}
