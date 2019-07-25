using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Fish : Pets
    {
        public Fish(string name, string owner, string kind)
        {
            this.name = name;
            this.owner = owner;
            this.kind = kind;
        }

        //first action
        public void swimm()
        {
            //if for kind
            {
                if (kind == "Guppy")
                {
                    Console.WriteLine("Schwimmt hin und her.");
                }
                else if (kind == "Goldfisch")
                {
                    Console.WriteLine("Schwimmt im Kreis.");
                }
                else
                {
                    Console.WriteLine("Undef.");
                }
            }
        }
    }
}
