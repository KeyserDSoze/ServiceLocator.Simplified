using System;
using System.Linq;

namespace ServiceLocator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simulation of 2 threads
            for (int i = 0; i < 2; i++)
            {
                //Simulation of a scoped service locator
                Manager manager = new Manager();

                //Transient
                Console.WriteLine($"Transient title: {manager.ReaderAsTransient.List().FirstOrDefault().Title}");
                Console.WriteLine($"Transient title: {manager.ReaderAsTransient.List().FirstOrDefault().Title}. This second title ever diverges from first.");

                //Scoped
                Console.WriteLine($"Scoped title: {manager.ReaderAsScoped.List().FirstOrDefault().Title}");
                Console.WriteLine($"Scoped title: {manager.ReaderAsScoped.List().FirstOrDefault().Title}. This second title is equal to previous title.");

                //Singleton
                if (i == 0)
                {
                    Console.WriteLine($"Singleton title: {manager.ReaderAsSingleton.List().FirstOrDefault().Title}");
                    Console.WriteLine($"Singleton title: {manager.ReaderAsSingleton.List().FirstOrDefault().Title}. This second title is equal to previous title.");
                }
                else
                    Console.WriteLine($"Singleton title: {manager.ReaderAsSingleton.List().FirstOrDefault().Title}. This title is equal to previous two titles in a previous thread.");
            }
        }
    }
}
