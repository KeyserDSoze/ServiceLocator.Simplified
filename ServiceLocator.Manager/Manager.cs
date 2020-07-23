using ServiceLocator.Abstractions;
using System;
using System.Collections.Generic;

namespace ServiceLocator
{
    //this manager must be created as a scoped variable
    //to respect the algebra of lifecycle
    //scoped x scoped = scoped
    //scoped x transient = transient
    //scoped x singleton = singleton
    //in case of a manager as transient you have
    //transient x scoped = transient
    //transinet x transinet = transient
    //transient x singleton = singleton
    //you lack in scoped
    //singleton x scoped = singleton
    //singleton x transient = transient
    //singleton x singleton = singleton
    //you lack again in scoped
    //only scoped manager allows you to have all 3 lifecycles.
    public class Manager
    {
        //transient or factory
        public IReadable ReaderAsTransient => new Library(this); //usually we have a factory or abstract factory here

        //scoped or flyweight
        private IReadable readerAsScoped; // the operator ??= makes difference, create a new instance only the first time is called.
        public IReadable ReaderAsScoped => readerAsScoped ??= new Library(this); //usually we have a flyweight here

        //singleton
        private static IReadable readerAsSingleton; //static makes difference
        public IReadable ReaderAsSingleton => readerAsSingleton ??= Library.Instance; //simulated singleton, we may have here a Multiton
    }
}
