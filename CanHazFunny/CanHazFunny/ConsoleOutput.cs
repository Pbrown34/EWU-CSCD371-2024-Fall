namespace CanHazFunny;
using System;
    internal sealed class ConsoleOutput : IOutputter
    {
        public void ConsoleOutputter(string joke)
        {
            if (string.IsNullOrEmpty(joke))
            {
                throw new ArgumentNullException("Joke passed to Console Output is nullorempty");
            }
            Console.WriteLine(joke);
        }
    }
