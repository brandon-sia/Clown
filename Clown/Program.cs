using System;

namespace Clown
{
    interface IClown
    {
        string FunnyThingIHave { get; }
        void Honk();
    }
    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();
    }

    class FunnyFunny:IClown
    {
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get { return funnyThingIHave; }
        }

        public FunnyFunny(string thing)
        {
            funnyThingIHave = thing;
        }
        public void Honk()
        {
            Console.WriteLine("Hi kids! I have a " + FunnyThingIHave + ".");
        }
    }

    class ScaryScary : FunnyFunny,IScaryClown
    {
        private readonly int scaryThingCount;
        public ScaryScary(int scaryThingCount, string funnyThingIHave):base(funnyThingIHave)
        {
            this.scaryThingCount = scaryThingCount;
        }
        public string ScaryThingIHave
        {
            get { return scaryThingCount + " spiders"; }
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            IClown fingersTheClown = new ScaryScary(14, "big red nose");
            fingersTheClown.Honk();

            if (fingersTheClown is IScaryClown iScaryClownReference)
            {
                iScaryClownReference.ScareLittleChildren();
            }
            
        }
    }
}
