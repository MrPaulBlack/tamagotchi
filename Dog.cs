using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Dog : Pets
    {

        public Dog(string name, string owner, string kind)
        {
            this.name = name;
            this.owner = owner;
            this.kind = kind;
        }

        //first action
        public void play()
        {
            Console.WriteLine("Hier entsteht was.");
        }       
    }
}
