using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MakeBreakfast
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("PourCoffe");
            Console.WriteLine("FryEggs");
            Console.WriteLine("FryBacon");
            Console.WriteLine("Toast bread");
            Console.WriteLine("Apply Butter");
            Console.WriteLine("ApplyJam");
            Console.WriteLine("PourJouce");

            Console.ReadLine();

            //MakeBreakfast();
            // When you write client programs, you want the UI to be responsive to user input.
            // Your application shouldn't make a phone appear frozen while it's downloading data from the web.
            // When you write server programs, you don't want threads blocked. Those threads could be serving other requests.
            // Using synchronous code when asynchronous alternatives exist hurts your ability to scale out less expensively. You pay for those blocked threads.

            MakeBreakfastAsync();

        }

        private static void MakeBreakfast()
        {
            

            Coffee cup = PourCoffee();
            
            Egg eggs = FryEggs(2);
            eggs.Fry();

            Bacon bacon = FryBacon(3);
            bacon.fry();
            
            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            
            Juice oj = PourOJ();
            

            Console.WriteLine("Breakfast is ready!");
        }

        private static void MakeBreakfastAsync()
        {


            Coffee cup = PourCoffee();

            //Task<Egg> getEggTask = 
            Task<Egg> eggs = FryEggsAsync(2);

            Task<Bacon> bacon = FryBaconAsync(3);

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);

            Juice oj = PourOJ();


            Console.WriteLine("Breakfast is ready!");
        }

        static Coffee PourCoffee()
        {
            return new Coffee();
        }

        public static Egg FryEggs(int N)
        {
            return new Egg();
        }

        public static async Task<Egg> FryEggsAsync(int N)
        {
            Egg egg = new Egg();
            await Task.Run(() => { egg.Fry(); });
            return egg;
        }

        static Bacon FryBacon(int N)
        {
            return new Bacon();
        }

        static async Task<Bacon> FryBaconAsync(int n)
        {
            Bacon bacon = new Bacon();
            await Task.Run(() => { bacon.fry(); });
            return bacon;
        }

        static Toast ToastBread(int N)
        {
            return new Toast();
        }

        static void ApplyButter(Toast toast)
        {
            toast.ApplyButter();
        }

        static void ApplyJam(Toast toast)
        {
            toast.ApplyJam();
        }

        static Juice PourOJ()
        {
            return new Juice();
        }
    }

    public class Coffee
    {
        public string CoffeeType { get; set; }
        public int Size { get; set; }
        //private Timer timer;

        public Coffee()
        {
           Thread.Sleep(3000);
           Console.WriteLine("coffee is ready");
        }

       
    }

    class Egg
    {
        public int Number { get; set; }
        public string CookType { get; set; }

        public Egg()
        {
            
        }

        public void Fry()
        {
            Thread.Sleep(15000);
            Console.WriteLine("eggs are ready");
        }

        
    }

    class Bacon
    {
        public int Amount { get; set; }

        public Bacon()
        {
           
        }

        public void fry()
        {
            Thread.Sleep(15000);
            Console.WriteLine("bacon is ready");
        }
    }

    class Toast
    {
        public int Amount { get; set; }

        public Toast()
        {
            Thread.Sleep(10000);
            Console.WriteLine("toast is ready");
        }
        public void ApplyButter()
        {
            
            Thread.Sleep(2000);
            Console.WriteLine("toast + butter");
        }

        public void ApplyJam()
        {
            
            Thread.Sleep(2000);
            Console.WriteLine("toast + butter + jam");
        }
    }

    class Juice
    {
        public float Amount { get; set; }

        public Juice()
        {
            Thread.Sleep(2000);
            Console.WriteLine("oj is ready");
        }
    }
}
