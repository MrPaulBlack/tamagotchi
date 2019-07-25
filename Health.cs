using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Health
    {
        //stats from selected pet
        public int food;
        public int water;
        public int cleaned;
        public Boolean alive = true;

        public int eat = 0;
        public int drink = 0;
        public int dirty = 0;

        public Health(int food, int water, int cleaned)
        {
            this.food = food;
            this.water = water;
            this.cleaned = cleaned;
        }

        public void give_food()
        {
            food = food + eat +2;
            Console.WriteLine("Du hast dein Tier gefüttert.");
            if (food > 10)
            {
                food = 10;
            }
        }

        public void give_water()
        {
            water = water + drink +2;
            Console.WriteLine("Dein Tier drinkt.");
            if (water > 10)
            {
                water = 10;
            }
        }

        public void give_bath()
        {
            cleaned = cleaned + dirty +2;
            Console.WriteLine("Du hast dein Tier gereinigt.");
            if (cleaned > 10)
            {
                cleaned = 10;
            }
        }
    }
}
