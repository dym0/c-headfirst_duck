using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Program
    {
        class Bird
        {
            public string Name { get; set; }

            public virtual void Fly()
            {
                Console.WriteLine("Frrr Frrr Frrr");
            }

            public override string ToString()
            {
                return "Bird " + Name;
            }


        }

        class Duck : Bird, IComparable<Duck>
        {
            public int Size;
            public KindOfDuck Kind;

            public void Quack() { Console.WriteLine("QUack QUack Quack"); }

            public void Swim(){}

            public void Eat(){}
            public void Walk(){}


            public int CompareTo(Duck duckToCompare)
            {
                if(this.Size < duckToCompare.Size)
                    return 1;                          // jesli tu zmienie na - 1 
                
                if(this.Size > duckToCompare.Size) // a tu na 1, to posortuje od najmniejszej do najwiekszej, 
                    return -1;
                
                else
                    return 0;
                
            }

            public override string ToString()
            {
                return Size + " -cm duck " + Kind.ToString();
            }
        }

        class DuckComparerBySize : IComparer<Duck> // klasa sortujaca po rozmiarze
        {

            public int Compare(Duck x, Duck y)
            {
                if (x.Size > y.Size)
                    return 1;
                if (x.Size < y.Size)
                    return -1;
                else
                    return 0;
            }
        }


        class DuckCompareByKind : IComparer<Duck>
        {

            public int Compare(Duck x, Duck y)
            {
                if (x.Kind < y.Kind)
                    return 1;
                if (x.Kind > y.Kind)
                    return -1;
                else
                    return 0;
            }
        }

        public enum KindOfDuck
        {
            Mallard,
            Muscovy,
            Decoy
        }

        
        class Penguin : Bird
        {
            public override void Fly()
            {
                Console.WriteLine("Penguins dont fly!");
            }

            public override string ToString()
            {
                return "Penguin " + base.Name;
            }
        }
          

        static void Main(string[] args)
        {

            List<Duck> ducks = new List<Duck>() {

                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11},
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14},
                new Duck() { Kind = KindOfDuck.Decoy, Size = 13 }
            };

            IEnumerable<Bird> upcastDuck = ducks;
           

            DuckComparerBySize compareDuckBySize = new DuckComparerBySize();
            DuckCompareByKind compareDuckByKind = new DuckCompareByKind();




         

            List<Bird> birds = new List<Bird>();
            birds.AddRange(upcastDuck);

            birds.Add( new Bird() { Name = "Rajski Ptak" });
            birds.Add(new Penguin() { Name = "Kowalski" });

            foreach (Bird bird in birds)
            {
                Console.WriteLine(bird);


            }

            ////ducks.Sort(compareDuckBySize);
            ////ducks.Sort(compareDuckByKind);
            ////Console.WriteLine("Sorted ducks ");

            //foreach (Duck duck in ducks)
            //{
            //    Console.WriteLine(duck);


            //}

            Console.ReadKey();
        }
    }
}
