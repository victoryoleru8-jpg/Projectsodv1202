using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceActivity
{
    public class Animal
    {
        public string Name { get; set; }
        public int Legs { get; set; }

        public Animal()
        {
            Name = "Animal";
            Legs = 0;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual string GetLegs()
        {
            return Legs.ToString();
        }

        public virtual string GetSpecialAbility()
        {
            return "\nEating...";
        }

        public string Display()
        {
            return GetName() + " " + GetLegs() + GetSpecialAbility();
        }

        public override string ToString()
        {
            return Display() + "\n";
        }
    }

    public class Dog : Animal
    {
        public Dog()
        {
            Name = "Dog";
            Legs = 4;
        }

        public override string GetSpecialAbility()
        {
            return "\nWoof";
        }
    }

    public class Fish : Animal
    {
        public Fish()
        {
            Name = "Fish";
            Legs = 0;
        }

        public override string GetSpecialAbility()
        {
            return "\nJust keep swimming";
        }
    }

    public class Shark : Fish
    {
        private Animal lastAnimal;

        public Shark(Animal animal)
        {
            Name = "Shark";
            Legs = 0;
            lastAnimal = animal;
        }

        public override string GetSpecialAbility()
        {
            return "\nShark ate " + lastAnimal.GetName();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* The main method is complete.
             * You do not need to modify the main method code.
             */

            Animal lastAnimal = null;
            Animal animal = null;
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                if (input == "animal")
                {
                    animal = new Animal();
                    lastAnimal = animal;
                }
                else if (input == "dog")
                {
                    animal = new Dog();
                    lastAnimal = animal;
                }
                else if (input == "fish")
                {
                    animal = new Fish();
                    lastAnimal = animal;
                }
                else if (input == "shark")
                {
                    animal = new Shark(lastAnimal);
                    lastAnimal = animal;
                }
                else if (input == "exit")
                {
                    return;
                }

                Console.WriteLine(animal);
            }
        }
    }
}