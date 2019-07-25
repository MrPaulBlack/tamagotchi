using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, num_max, select = 0, select_breed = 0, select_action = 0;     //i for for-loop, num_max for number of pets, select and select_breed for pet selection
            int randm_bool;      //randm_num1,2,3 for name-select
            string fish_kind;       //fishkind -> Goldfish or Guppy
            Boolean active = true, main_active = true;      //active for while-loop as logic switch, main for main screen until abort
            Random rnd = new Random();      //randm obj for int gen
            string[] names = System.IO.File.ReadAllLines(@"names.txt");    //import textfile in array
            string[] dog_breed = System.IO.File.ReadAllLines(@"dog.txt");    //import textfile in array
            int day = 1;      //number of days

            // number of pets, input, set props
            Console.Write("Anzahl der Tiere: ");
            //sanitizer
            while (!Int32.TryParse(Console.ReadLine(), out num_max))
            {
                Console.WriteLine("Ungültige Zahl.");
                Console.Write("gib die Anzahl der Tiere an: ");
            }

            //init objects, pets
            Dog[] dog = new Dog[num_max];
            Fish[] fish = new Fish[num_max];

            //clear console for output
            Console.Clear();

            for (i = 0; i <= num_max -1; i++)
            {
                dog[i] = new Dog(names[rnd.Next(0, names.Length)], names[rnd.Next(0, names.Length)], dog_breed[rnd.Next(0, dog_breed.Length)]);
                Console.WriteLine(Convert.ToString(i + 1) + ". Hundename:    " + dog[i].get_name());
                Console.WriteLine(Convert.ToString(i + 1) + ". Hunderasse:   " + dog[i].get_kind());
                Console.WriteLine(Convert.ToString(i + 1) + ". Besitzer:     " + dog[i].get_owner());

                //insert line
                Console.WriteLine("");

                randm_bool = rnd.Next(0, 2);
                {
                    if (randm_bool == 0)
                    {
                        fish_kind = "Guppy";
                    }
                    else
                    {
                        fish_kind = "Goldfisch";
                    }
                }
                fish[i] = new Fish(names[rnd.Next(0, names.Length)], names[rnd.Next(0, names.Length)], fish_kind);
                Console.WriteLine(Convert.ToString(i +1) + ". Fischname:    " + fish[i].get_name());
                Console.WriteLine(Convert.ToString(i + 1) + ". Fischart:     " + fish[i].get_kind());
                Console.WriteLine(Convert.ToString(i + 1) + ". Besitzer:     " + fish[i].get_owner());

                //insert line
                Console.WriteLine("");
            }

            //select a pet
            while (active == true) {
                Console.Write("Wähle ein Tier: ");
                //sanitizer
                while (!Int32.TryParse(Console.ReadLine(), out select))
                {
                    Console.WriteLine("Ungültige Zahl.");
                    Console.Write("Wähle ein Tier: ");
                }
                {
                    if (select > num_max || select <= 0)
                    {
                        Console.WriteLine("Wähle ein gültiges Tier.");
                    }
                    else
                    {
                        active = false;
                    }
                }
            }
            select = select - 1;

            //set active to default for next while-loop
            active = true;

            while (active == true)
            {
                Console.WriteLine("Wähle: ");
                Console.WriteLine("1. Hund");
                Console.WriteLine("2. Fisch");
                //sanitizer
                while (!Int32.TryParse(Console.ReadLine(), out select_breed))
                {
                    Console.WriteLine("Ungültige Zahl.");
                    Console.WriteLine("Wähle: ");
                    Console.WriteLine("1. Hund");
                    Console.WriteLine("2. Fisch");
                }
                {
                    if (select_breed > 2 || select_breed <= 0)
                    {
                        Console.WriteLine("Treffe eine gültige Auswahl.");
                    }
                    else
                    {
                        active = false;
                    }
                }
            }

            //set active to default for next while-loop
            active = true;

            //init health stats with default 10, generate randm stats, from 5 to 10
            Health health = new Health(rnd.Next(5, 11), rnd.Next(5, 11), rnd.Next(5, 11));
            //habbits between 1 and 3
            health.eat = rnd.Next(1, 4);
            health.drink = rnd.Next(1, 4);
            health.dirty = rnd.Next(1, 4);

            while (main_active == true) { 
                //console clear
                Console.Clear();

                //output day, pet keept alive
                {
                    if (day == 1)
                    {
                        Console.WriteLine(Convert.ToString(day) + " Tag am leben.");
                    }
                    else
                    {
                        Console.WriteLine(Convert.ToString(day) + " Tage am leben.");
                    }
                }
                Console.WriteLine("");

                //output selected pet
                {
                    if (select_breed == 1)      //dog
                    {
                        Console.WriteLine("Hundename:    " + dog[select].get_name());
                        Console.WriteLine("Hunderasse:   " + dog[select].get_kind());
                        Console.WriteLine("Besitzer:     " + dog[select].get_owner());
                    }
                    else if (select_breed == 2)     //fish
                    {
                        Console.WriteLine("Fischname:    " + fish[select].get_name());
                        Console.WriteLine("Fischart:     " + fish[select].get_kind());
                        Console.WriteLine("Besitzer:     " + fish[select].get_owner());
                    }
                    else { }
                }

                //set active to true for while -loop
                active = true;
                Console.WriteLine("");      //return

                //display stats
                Console.WriteLine("Nahrung:      " + Convert.ToString(health.food) + ", in der nächsten Runde: " + Convert.ToString(health.food - health.eat) + ", -"+ Convert.ToString(health.eat) + " pro Runde");
                Console.WriteLine("Trinken:      " + Convert.ToString(health.water) + ", in der nächsten Runde: " + Convert.ToString(health.water - health.drink) + ", -" + Convert.ToString(health.drink) + " pro Runde");
                Console.WriteLine("Sauberkeit:   " + Convert.ToString(health.cleaned) + ", in der nächsten Runde: " + Convert.ToString(health.cleaned - health.dirty) + ", -" + Convert.ToString(health.dirty) + " pro Runde");
                Console.WriteLine("");

                {
                    if (select_breed == 1)      //dog
                    {                 
                        while (active == true)
                        {
                            Console.WriteLine("Wähle eine Aktion: ");
                            Console.WriteLine("1. Program beenden.");
                            Console.WriteLine("2. Spiele mit deinem Hund.");
                            Console.WriteLine("3. Füttere deinen Hund.");
                            Console.WriteLine("4. Gebe deinem Hund etwas zu trinken.");
                            Console.WriteLine("5. Reinige deinen Hund.");
                            //sanitizer
                            while (!Int32.TryParse(Console.ReadLine(), out select_action))
                            {
                                Console.WriteLine("Ungültige Zahl.");
                                Console.WriteLine("1. Program beenden.");
                                Console.WriteLine("2. Spiele mit deinem Hund.");
                                Console.WriteLine("3. Füttere deinen Hund.");
                                Console.WriteLine("4. Gebe deinem Hund etwas zu trinken.");
                                Console.WriteLine("5. Reinige deinen Hund.");
                            }
                            {
                                if (select_action > 5 || select_action <= 0)
                                {
                                    Console.WriteLine("Treffe eine gültige Auswahl.");
                                }
                                else
                                {
                                    active = false;
                                }
                            }
                        }
                    }
                    else if (select_breed == 2)     //fish
                    {
                        while (active == true)
                        {
                            Console.WriteLine("Wähle eine Aktion: ");
                            Console.WriteLine("1. Program beenden.");
                            Console.WriteLine("2. Teste, wie der Fisch schwimmt.");
                            Console.WriteLine("3. Füttere deinen Fisch.");
                            Console.WriteLine("4. Gebe deinem Fisch etwas zu trinken.");
                            Console.WriteLine("5. Reinige deinen Fisch.");
                            //sanitizer
                            while (!Int32.TryParse(Console.ReadLine(), out select_action))
                            {
                                Console.WriteLine("Ungültige Zahl.");
                                Console.WriteLine("1. Program beenden.");
                                Console.WriteLine("2. Teste, wie der Fisch schwimmt.");
                                Console.WriteLine("3. Füttere deinen Fisch.");
                                Console.WriteLine("4. Gebe deinem Fisch etwas zu trinken.");
                                Console.WriteLine("5. Reinige deinen Fisch.");
                            }
                            {
                                if (select_action > 5 || select_action <= 0)
                                {
                                    Console.WriteLine("Treffe eine gültige Auswahl.");
                                }
                                else
                                {
                                    active = false;
                                }
                            }
                        }
                    }
                    else { }
                }

                //next screen, do selected activity
                Console.Clear();
                {
                    if (select_breed == 1 && select_action == 1)            //dog
                    {
                        main_active = false;
                        Console.WriteLine(dog[select].get_name() + " wird dich vermissen.");
                    }
                    else if (select_breed == 2 && select_action == 1)       //fish
                    {
                        main_active = false;
                        Console.WriteLine(fish[select].get_name() + " wird dich vermissen.");
                    }
                    else if (select_breed == 1 && select_action == 2)      //dog
                    {
                        dog[select].play();
                    }
                    else if (select_breed == 2 && select_action == 2)     //fish
                    {
                        fish[select].swimm();
                    }
                    else if (select_action == 3)     //health class
                    {
                        health.give_food();
                    }
                    else if (select_action == 4)     //health class
                    {
                        health.give_water();
                    }
                    else if (select_action == 5)     //health class
                    {
                        health.give_bath();
                    }
                    else { }

                    //next day
                    day = day + 1;
                    health.food = health.food - health.eat;
                    health.water = health.water - health.drink;
                    health.cleaned = health.cleaned - health.dirty;

                    //test if pet is dead
                    if (health.food <= 0 || health.water <= 0 || health.cleaned <= 0)
                    {
                        health.alive = false;
                    }

                    //end main activity, if pet is dead
                    if (health.alive == false)   
                    {
                        {
                            if (select_breed == 1)  //dog
                            {
                                main_active = false;
                                Console.WriteLine("");
                                Console.WriteLine(dog[select].get_name() + " ist gestorben.");
                                Console.WriteLine("Er/Sie hat " + Convert.ToString(day - 1) + " Tage überlebt.");
                            }
                            else if (select_breed == 2)  //fish
                            {
                                main_active = false;
                                Console.WriteLine("");
                                Console.WriteLine(fish[select].get_name() + " ist gestorben.");
                                Console.WriteLine("Er/Sie hat " + Convert.ToString(day - 1) + " Tage überlebt.");
                            }
                            else { }
                        }
                    }
                }

                //wait for user input
                Console.ReadLine();
            }
        }
    }
}
